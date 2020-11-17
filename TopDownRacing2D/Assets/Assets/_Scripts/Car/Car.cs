using UnityEngine;

/// <summary>
/// Vehicle script which has the Vehicle controller functionality implemented
/// </summary>
public class Vehicle : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;


    /// <summary>
    /// Function Responsible for Accelerating the Vehicle
    /// </summary>
    /// <param name="accDir"> The Direction in which we want the car to accelerate</param>
    public void Accelerate( float accDir)
    {
        transform.Translate(transform.up *  accDir * speed * Time.deltaTime);
    }

    /// <summary>
    /// Function Responsible for Moving the Vehicle Left and Right
    /// </summary>
    /// <param name="steerDir">The Direction in which we want the Vehicle to Move</param>
    public void Steer(float steerDir)
    {
        transform.Translate(transform.right * steerDir * speed * Time.deltaTime);
    }

}
