using UnityEngine;

public class Region : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefArea;
    [SerializeField]
    private GameObject _prefBorder;
    [SerializeField]
    private GameObject _prefHuman;

    private Transform _areasTransform;
    private Transform _bordersTransform;

    private static Border[] _borders;
    public readonly int size = 100;

    private void Awake()
    {
        _areasTransform = transform.Find("Areas");
        _bordersTransform = transform.Find("Borders");
        CreateGround();
        Region._borders = _bordersTransform.GetComponentsInChildren<Border>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnEntity", 1, 3);
    }

    private void CreateGround()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                GameObject ground;
                if (x == 0 || x == (size - 1) || y == 0 || y == (size - 1))
                {
                    ground = Instantiate(_prefBorder, _bordersTransform);
                }
                else
                {
                    ground = Instantiate(_prefArea, _areasTransform);
                }
                ground.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    private void SpawnEntity()
    {
        Vector3 pos = Region.GetRandomBorderPos();
        Instantiate(_prefHuman, pos, Quaternion.identity);
    }

    public static Vector3 GetRandomBorderPos()
    {
        return Region._borders[Random.Range(0, Region._borders.Length)].transform.position;
    }

}
