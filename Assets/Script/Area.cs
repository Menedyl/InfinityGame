using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public List<string> CardinalPointsBorder;

    private void Start()
    {
        if (CompareTag("Border"))
        {
            SetCardinalPoints();
        }
    }

    private void SetCardinalPoints()
    {
        string[] m = name.Split('-');
        switch (m[0])
        {
            case "1":
                CardinalPointsBorder.Add("West");
                break;
            case "20":
                CardinalPointsBorder.Add("East");
                break;
        }

        switch (m[1])
        {
            case "1":
                CardinalPointsBorder.Add("South");
                break;
            case "20":
                CardinalPointsBorder.Add("North");
                break;
        }
    }
}
