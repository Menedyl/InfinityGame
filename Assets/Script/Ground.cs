using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public Area prefArea;
    public List<Area> Borders;
    private readonly System.Random Rand = new System.Random();

    private void Awake()
    {
        InitGround();
        AddBorder();
    }

    private void InitGround()
    {
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                Area area = Instantiate(prefArea, transform);
                area.transform.localPosition += new Vector3(x, y);
                area.name = (x + 1) + "-" + (y + 1);
            }
        }
    }

    private void AddBorder()
    {
        string regex = "^1-|^20-|-1$|-20$";
        Area[] areas = GetComponentsInChildren<Area>();
        foreach (Area area in areas)
        {
            //Si "Area" est au bord de "Ground"    
            if (Regex.IsMatch(area.name, regex))
            {
                area.tag = "Border";
                Borders.Add(area);
            }
        }
    }

    public Area GetRandomBorder()
    {
        return Borders[Rand.Next(Borders.Count)];
    }


}
