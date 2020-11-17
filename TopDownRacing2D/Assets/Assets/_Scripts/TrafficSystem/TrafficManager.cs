using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class That has all the required stuff to manage and control the traffic
/// </summary>
public class TrafficManager : MonoBehaviour
{
    public float trafficSpeed;
    public int activeVehicles; //max number of vehicles allowed in the scene

     
    private  Transform player;
    public Transform trafficCar;
    public Transform trafficSpawner;
    public List<Traffic> trafficVehicles;
    public List<Traffic> liveVehilces;

    public void InitTrafficManager(Transform player_)
    {
        player = player_;
        CreateTraffic();
    }

    public void SetVehicleSpawner()
    {
        if (trafficSpawner)
        {
            trafficSpawner.GetComponent<TrafficSpawner>().InitSpawner(player);
            trafficSpawner.position = Vector3.zero;
            trafficSpawner.rotation = Quaternion.identity;
        }           
    }

    void CreateTraffic()
    {
        for (int i = 0; i < activeVehicles; i++)
        {
            GameObject vehicle = Instantiate(trafficCar.gameObject, transform);
            vehicle.SetActive(false);
  
            Traffic traffic = vehicle.GetComponent<Traffic>();
            if (traffic)
            {
                trafficVehicles.Add(traffic);
            }
             
        }
    }

    public Traffic SpawnTraffic()
    {
        if (trafficVehicles.Count != 0)
        {
            Traffic traffic = trafficVehicles[0];
            trafficVehicles.RemoveAt(0);
            liveVehilces.Add(traffic);
            return traffic;
        }
        return null;
    }

    public void TrafficDespawn(Traffic traffic)
    {
        traffic.DeActivate();
        trafficVehicles.Add(traffic);
    }

    public void DisableTraffic()
    {
        trafficSpawner.gameObject.SetActive(false);
        while (liveVehilces.Count != 0)
        {
            Traffic traffic = liveVehilces[0];
            liveVehilces.RemoveAt(0);
            TrafficDespawn(traffic); 
        }
    }
}
