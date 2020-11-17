using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public float spawnOffset;
    public TrafficManager trafficManager;

    public float spawnDelay;

    private float timer;

    private Transform player;

    public List<Transform> trafficSpawnPositions;

    public void InitSpawner(Transform _player)
    {
        player = _player;
    }

    private void Update()
    {
        if (GameManager.GM.gameState != GameManager.GameState.GamePlay) return;

        SpawnCar();
        FollowPlayer();
    }

    /// <summary>
    /// Spawns the Traffic vehicle
    /// </summary>
    private void SpawnCar()
    {
        timer += Time.deltaTime;
        if (timer > spawnDelay && canSpawnTraffic())
        {
            timer = 0;
            SetTrafficVehicle(trafficManager.SpawnTraffic());
        }
    }

    /// <summary>
    /// Function that receives the Traffic vehicle and sets its initial values for the Traffic to Initialize
    /// </summary>
    /// <param name="traffic_">Traffic vehicle</param>
    private void SetTrafficVehicle(Traffic traffic_)
    {
        int spawnPosCount = trafficSpawnPositions.Count;
        int randomSpawnPosIndex = RandomSpawnPosIndex(0, spawnPosCount);

        traffic_.InitTraffic(1.5f, trafficSpawnPositions[randomSpawnPosIndex].position, spawnOffset);
    }

    private int RandomSpawnPosIndex(int min , int max)
    {
        return Random.Range(min, max);
    }

    private void FollowPlayer()
    {
        if (player)
        {
            float player_Y_Pos = player.transform.position.y;
            Vector3 tempPos = transform.position;
            tempPos.y = player_Y_Pos;
            transform.position = tempPos;
        }
    }

    private bool canSpawnTraffic()
    {
        if (trafficManager.trafficVehicles.Count > 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Event is Called when Traffic vehicle no longer in view
    /// </summary>
    /// <param name="collision">Collider that has initiated this event call</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Traffic"))
        {
            trafficManager.TrafficDespawn(collision.GetComponent<Traffic>());
        }
    }
}
