using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefRegion;
    [SerializeField]
    private Transform _transformWorld;

    private void Awake()
    {
        Instantiate(_prefRegion, _transformWorld);
    }

}
