using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask soldierMask, tileMask;
    private Soldier selectedSoldier;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (selectedSoldier == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.1f, soldierMask);
                if (hit.collider != null)
                {
                    Soldier s = hit.collider.GetComponent<Soldier>();
                    if (s.team == TeamType.Player1) 
                        selectedSoldier = s;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0.1f, tileMask);
                if (hit.collider != null)
                {
                    HexTile tile = hit.collider.GetComponent<HexTile>();
                    if (tile.tileOwner == selectedSoldier.team)
                    {
                        selectedSoldier.MoveTo(tile.hexCoords, tile.transform.position);
                        selectedSoldier = null;
                    }
                }
            }
        }
    }
}
