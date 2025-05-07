using UnityEngine;

public class HexTile : MonoBehaviour
{
    public Vector2Int hexCoords;
    public TeamType tileOwner = TeamType.None;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetOwner(TeamType team)
    {
        tileOwner = team;
        sr.color = team == TeamType.None ? Color.gray : (team == TeamType.Player1 ? Color.blue : Color.red);
    }
}
