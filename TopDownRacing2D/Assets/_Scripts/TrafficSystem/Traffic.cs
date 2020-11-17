using UnityEngine;

public class Traffic : Vehicle
{
    private bool isInitialized;

    private void FixedUpdate()
    {
        if (isInitialized)
        {
            Accelerate(-speed);
        }
    }

    /// <summary>
    /// Function that is called to Initialize and enable the traffic vehicle
    /// </summary>
    /// <param name="_speed">the speed of Traffic Car</param>
    /// <param name="spawnPos">what will be the spawn position</param>
    /// <param name="y_Offset">the offset value from the actual spawn position</param>
    public void InitTraffic(float _speed , Vector3 spawnPos , float y_Offset)
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
        speed = _speed;
        isInitialized = true;

        spawnPos.y += y_Offset;

        transform.position = spawnPos;
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        isInitialized = false;
        transform.gameObject.SetActive(false);
    }

}
