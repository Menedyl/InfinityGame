using UnityEngine;

public class World : MonoBehaviour
{
    public Region prefRegion;
    private readonly System.Random Rand = new System.Random();

    private void Awake()
    {
        Instantiate(prefRegion, transform);
    }

    public Region GetRandomRegion()
    {
        return GetComponentsInChildren<Region>()[Rand.Next(GetComponentsInChildren<Region>().Length)];
    }

}
