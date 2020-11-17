using UnityEngine;

/// <summary>
/// Call Responsible for detecting whether Player Triggered with the track patch
/// </summary>
public class RoadTrigger : MonoBehaviour
{
    public RoadHandler roadHandler;

    /// <summary>
    /// When Player Car Triggers with the end of the patch this event is Triggered
    /// </summary>
    /// <param name="collision">Collider that has initiated this event call </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             if (roadHandler)
                roadHandler.ChangeRoadPatch();
        }
    }
}
