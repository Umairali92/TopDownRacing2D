using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
 
    public enum GameState { InitGame , GamePlay , LevelFail };
    public GameState gameState;

    private void Awake()
    {
        if (GM) Destroy(GM);
        GM = this;
    }

    private void Start()
    {
        GameStateManaege(GameState.InitGame);
    }

    public void GameStateManaege(GameState _gameState)
    {
         gameState = _gameState;
        switch (gameState)
        {
            case GameState.InitGame:
                InitGame();
                break;
            case GameState.GamePlay:
                SetGameplay();
                break;
            case GameState.LevelFail:
                LevelFail();
                break;
             
        }
    }

    void SetGameplay()
    {
        GameReff.gameReff.playerHandler.CreatePlayer(GameReff.gameReff.vehicleSelection.GetActivePlayerSkin());
        GameReff.gameReff.trafficManager.InitTrafficManager(GameReff.gameReff.playerHandler.ActivePlayer().transform);
        GameReff.gameReff.trafficManager.SetVehicleSpawner();
    }

    void InitGame()
    {
        GameReff.gameReff.vehicleSelection.InitVehicleSelection();
        gameState = GameState.InitGame;
    }

    void LevelFail()
    {
        GameReff.gameReff.trafficManager.DisableTraffic();
        GameReff.gameReff.levelFailed.gameObject.SetActive(true);
    }

}
