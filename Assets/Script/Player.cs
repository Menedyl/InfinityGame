using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public World world;

    public bool IsPosBorderNorth = false;
    public bool IsPosBorderEast = false;
    public bool IsPosBorderWest = false;
    public bool IsPosBorderSouth = false;


    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && IsPosBorderNorth == false)
        {
            transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.S) && IsPosBorderSouth == false)
        {
            transform.Translate(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.Q) && IsPosBorderWest == false)
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D) && IsPosBorderEast == false)
        {
            transform.Translate(Vector3.right);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            ToggleIsPosBorder(collision.GetComponent<Area>().CardinalPointsBorder, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            ToggleIsPosBorder(collision.GetComponent<Area>().CardinalPointsBorder, false);
        }
    }

    private void Spawn()
    {
        Area area = world.GetRandomRegion().GetComponentInChildren<Ground>().GetRandomBorder();
        transform.position = (area.transform.position + new Vector3(0.5f, 0.5f));
    }

    private void ToggleIsPosBorder(List<string> borders, bool value)
    {
        foreach (string border in borders)
        {
            switch (border)
            {
                case "North":
                    IsPosBorderNorth = value;
                    break;
                case "East":
                    IsPosBorderEast = value;
                    break;
                case "South":
                    IsPosBorderSouth = value;
                    break;
                case "West":
                    IsPosBorderWest = value;
                    break;
            }

        }
    }


}
