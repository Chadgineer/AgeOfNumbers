using UnityEngine;

public class HexGridManager : MonoBehaviour
{
    public static HexGridManager Instance { get; private set; }

    public GameObject hexPrefab;
    public int width;
    public int height;
    public float hexWidth;
    public float hexHeight;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
 
    }

    public Vector3 GetWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(gridPosition.x * hexWidth, 0, gridPosition.y * hexHeight);
    }
}
