using UnityEngine;

public class Player : Vehicle
{
    
    bool isplayerDead = false;
  
    public void InitPlayer(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    private void FixedUpdate()
    {
        if (isplayerDead && GameManager.GM.gameState != GameManager.GameState.GamePlay) return;

        Accelerate(Input.GetAxis("Vertical"));
        Steer(Input.GetAxis("Horizontal"));        
    }

    /// <summary>
    /// Event that is called when player collide with the traffic 
    /// </summary>
    /// <param name="collision">Collider that has initiated this event call</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isplayerDead) return;

        if (collision.gameObject.CompareTag("Traffic"))
        {
            isplayerDead = true;
            GameManager.GM.GameStateManaege(GameManager.GameState.LevelFail);
        }
    }

}
