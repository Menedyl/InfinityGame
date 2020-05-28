using UnityEngine;

public class MoveControllerEntity : MonoBehaviour
{
    private enum Direction { North, East, South, West };
    private MoveControllerBorder _moveControllerBorder;

    private void Awake()
    {
        _moveControllerBorder = GetComponent<MoveControllerBorder>();
    }

    private void Start()
    {
        InvokeRepeating("MoveRandom", 1, 2);
    }

    private void MoveRandom()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case (int)Direction.North:
                if (!_moveControllerBorder.IsPosBorderNorth)
                {
                    transform.Translate(Vector3.up);
                }
                return;
            case (int)Direction.East:
                if (!_moveControllerBorder.IsPosBorderEast)
                {
                    transform.Translate(Vector3.right);
                }
                return;
            case (int)Direction.South:
                if (!_moveControllerBorder.IsPosBorderSouth)
                {
                    transform.Translate(Vector3.down);
                }
                return;
            case (int)Direction.West:
                if (!_moveControllerBorder.IsPosBorderWest)
                {
                    transform.Translate(Vector3.left);
                }
                return;
        }
    }
}
