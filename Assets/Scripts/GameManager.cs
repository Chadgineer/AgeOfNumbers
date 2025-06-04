using UnityEngine;
using TMPro; // Bunu ekle!

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TeamType currentPlayerTurn = TeamType.Player1;

    public int player1Money = 100;
    public int player2Money = 100;

    public GameObject[] soldierPrefabs;

    public TMP_Text playerInfoText; // 1-9 seviyedeki asker prefab'larý

    private int selectedSoldierLevel = -1;

    private void Start()
    {
        UpdatePlayerInfoUI();
    }



    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SelectSoldierLevel(int level)
    {
        selectedSoldierLevel = level;
        Debug.Log("Seçilen asker seviyesi: " + level);
    }

    public void UpdatePlayerInfoUI()
    {
        string player = currentPlayerTurn == TeamType.Player1 ? "Player 1" : "Player 2";
        int money = currentPlayerTurn == TeamType.Player1 ? player1Money : player2Money;

        playerInfoText.text = $"{player} : {money}";
    }


    public void TryPlaceSoldierOnTile(HexTile tile)
    {
        if (selectedSoldierLevel < 1 || selectedSoldierLevel > 9)
        {
            Debug.LogWarning("Geçersiz asker seviyesi!");
            return;
        }

        int cost = selectedSoldierLevel * 10;

        if (currentPlayerTurn == TeamType.Player1 && player1Money < cost)
        {
            Debug.Log("Yetersiz para!");
            return;
        }
        if (currentPlayerTurn == TeamType.Player2 && player2Money < cost)
        {
            Debug.Log("Yetersiz para!");
            return;
        }

        if (tile.tileOwner != currentPlayerTurn)
        {
            Debug.Log("Bu hücreye yerleþtiremezsin!");
            return;
        }

        Vector3 spawnPos = tile.transform.position;
        GameObject newSoldier = Instantiate(soldierPrefabs[selectedSoldierLevel - 1], spawnPos, Quaternion.identity);
        Soldier soldierComp = newSoldier.GetComponent<Soldier>();
        soldierComp.team = currentPlayerTurn;
        soldierComp.gridPosition = tile.hexCoords;

        if (currentPlayerTurn == TeamType.Player1) player1Money -= cost;
        else player2Money -= cost;

        Debug.Log("Asker yerleþtirildi! Kalan para: " +
            (currentPlayerTurn == TeamType.Player1 ? player1Money : player2Money));

        // Ýþte buraya ekle:
        UpdatePlayerInfoUI();

        selectedSoldierLevel = -1;
    }

    public void EndTurn()
    {
        currentPlayerTurn = (currentPlayerTurn == TeamType.Player1) ? TeamType.Player2 : TeamType.Player1;
        Debug.Log("Sýra þimdi: " + currentPlayerTurn);

        UpdatePlayerInfoUI();
    }
}
