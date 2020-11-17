using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameObject playerSourceObject;
    public Transform playerSpawnPos;

    private Player player;
    private Sprite activePlayerSkin;

    /// <summary>
    /// Function that instantiate the player and Calls its Intializers
    /// </summary>
    /// <param name="activePlayerSkin_">Active Player Skin from the list of skins available</param>
    public void CreatePlayer(Sprite activePlayerSkin_)
    {
        activePlayerSkin = activePlayerSkin_;
        GameObject tempPlayer = Instantiate(playerSourceObject, playerSpawnPos.position, playerSpawnPos.rotation);
        player = tempPlayer.GetComponent<Player>();
        SetPlayerValues(player);
        InitializePlayerCamera();
    }

    private void InitializePlayerCamera()
    {
        GameReff.gameReff.cameraFollow.InitCamera(player.transform);
    }

    private void SetPlayerValues(Player player_)
    {
        player_.InitPlayer(activePlayerSkin);
    }

    public Player ActivePlayer()
    {
        return player;
    }

}
