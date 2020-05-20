using UnityEngine;

public class Region : MonoBehaviour
{
    public Area prefArea;
    private readonly int size = 20;

    private void Start()
    {
        //Ajuste la taille du RectTransform pour contenir les "Area"
        GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);

        //Créer, place et renome les "Area" dans le RectTransform parent
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Area area = Instantiate(prefArea, transform);
                area.transform.localPosition = new Vector2(x, y);
                area.name = (x + 1) + "-" + (y + 1);
            }
        }

    }

}
