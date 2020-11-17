using UnityEngine;

/// <summary>
/// Class Which Holds all refrences needed to interconnect with other components
/// </summary>
public class GameReff : MonoBehaviour
{
    public static GameReff gameReff; 
    public LevelFailed levelFailed;
    public VehicleSelection vehicleSelection;

    private void Awake()
    {
        if (gameReff) Destroy(gameReff);
        gameReff = this;
    }

    [Space]
    public TrafficManager trafficManager;

    [Space]
    public PlayerHandler playerHandler;

    [Space]
    public CameraFollow cameraFollow;
}
