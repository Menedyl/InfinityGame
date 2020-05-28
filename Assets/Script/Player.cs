using UnityEngine;

public class Player : MonoBehaviour
{
    private MoveControllerBorder _moveControllerBorder;

    private void Awake()
    {
        _moveControllerBorder = GetComponent<MoveControllerBorder>();
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && _moveControllerBorder.IsPosBorderNorth == false)
        {
            transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.S) && _moveControllerBorder.IsPosBorderSouth == false)
        {
            transform.Translate(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.Q) && _moveControllerBorder.IsPosBorderWest == false)
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D) && _moveControllerBorder.IsPosBorderEast == false)
        {
            transform.Translate(Vector3.right);
        }
    }

    private void Spawn()
    {
        transform.position = Region.GetRandomBorderPos();
    }
}
