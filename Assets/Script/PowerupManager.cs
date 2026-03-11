using UnityEngine;

public class PowerupManager : MonoBehaviour
{
   [SerializeField] PowerupSC powerup;
   PlayerController playerController;

   SpriteRenderer spriteRenderer;

   float timerleft;
    void Start()
     {
          playerController = FindFirstObjectByType<PlayerController>(); // Find the PlayerController script in the scene
          spriteRenderer = GetComponent<SpriteRenderer>();
          timerleft=powerup.GetTime    ;
     }

    void Update()
    {   
        CountdownTimer();
    }

    void OnTriggerEnter2D(Collider2D collision){
     int layerIndex = LayerMask.NameToLayer("Player"); // find the index of the player layer
        if (collision.gameObject.layer == layerIndex && spriteRenderer.enabled) // Check if the collided object is on the player layer
        {
           playerController.ActivatePowerup(powerup);
           spriteRenderer.enabled = false; // Disable the sprite renderer to make the powerup invisible after being collected
           
        }
    }

    
    void CountdownTimer()
    {
        if(timerleft>0)
        {
            timerleft = timerleft-Time.deltaTime; // Decrease the timer by the time elapsed since the last frame
            
                if(timerleft<=0)
                {
                   print("Powerup expired!"); // Print a message to the console when the powerup expires
                   playerController.DeactivatePowerup(powerup); // Call the method to deactivate the powerup effect on the player
                }
            
        }
    }
}
