using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private enum Direction { North, East, South, West };
    private readonly List<Direction> _directions = new List<Direction>();

    private void Start()
    {
        int max = GetComponentInParent<Region>().size - 1;
        Vector3 pos = transform.position;
        if (pos.x == 0)
        {
            _directions.Add(Direction.West);
        }
        if (pos.x == max)
        {
            _directions.Add(Direction.East);
        }
        if (pos.y == 0)
        {
            _directions.Add(Direction.South);
        }
        if (pos.y == max)
        {
            _directions.Add(Direction.North);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TogglePosBorder(collision.GetComponent<MoveControllerBorder>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TogglePosBorder(collision.GetComponent<MoveControllerBorder>());
    }

    private void TogglePosBorder(MoveControllerBorder moveControllerBorder)
    {
        foreach (Direction dir in _directions)
        {
            switch (dir)
            {
                case Direction.North:
                    moveControllerBorder.IsPosBorderNorth = !moveControllerBorder.IsPosBorderNorth;
                    break;
                case Direction.East:
                    moveControllerBorder.IsPosBorderEast = !moveControllerBorder.IsPosBorderEast;
                    break;
                case Direction.South:
                    moveControllerBorder.IsPosBorderSouth = !moveControllerBorder.IsPosBorderSouth;
                    break;
                case Direction.West:
                    moveControllerBorder.IsPosBorderWest = !moveControllerBorder.IsPosBorderWest;
                    break;
            }
        }
    }
}
