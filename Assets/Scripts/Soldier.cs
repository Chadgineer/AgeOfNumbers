using System;
using UnityEngine;

public enum TeamType
{
    None = -1, 
    Player1 = 0,
    Player2 = 1
}

public class Soldier : MonoBehaviour
{
    public int level = 1;
    public TeamType team;
    public Vector2Int gridPosition;

    public int GetPower() => level;

    public void MoveTo(Vector2Int newPos)
    {

        transform.position = HexGridManager.Instance.GetWorldPosition(newPos);
        gridPosition = newPos;
    }
}
