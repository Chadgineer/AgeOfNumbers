using UnityEngine;

public class Soldier : MonoBehaviour
{
    public int level = 1;
    public TeamType team;
    public Vector2Int gridPosition;

    private void Start()
    {
        gridPosition = EstimateGridPosition(transform.position);
    }

    public int GetPower() => level;

    public void MoveTo(Vector2Int newPos, Vector3 worldPos)
    {
        transform.position = worldPos;
        gridPosition = newPos; 
    }


    private Vector2Int EstimateGridPosition(Vector3 position)
    {
        float hexWidth = 1f;
        float hexHeight = 0.86f;
        int y = Mathf.RoundToInt(position.y / hexHeight);
        float xOffset = (y % 2 == 0) ? 0 : hexWidth / 2f;
        int x = Mathf.RoundToInt((position.x - xOffset) / hexWidth);
        return new Vector2Int(x, y);
    }
}
