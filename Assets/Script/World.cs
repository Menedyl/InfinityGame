using UnityEngine;

public class World : MonoBehaviour
{
    public Region prefRegion;

    private void Start()
    {
        Region region = Instantiate(prefRegion, transform);
        region.GetComponent<RectTransform>().anchoredPosition = new Vector2(-10, -10);

    }
}
