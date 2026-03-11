using UnityEngine;

public class SnowTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem TrailParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision detected!");
        int layerIndex = LayerMask.NameToLayer("Floor"); // find the index of the floor layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the floor layer
        {
            TrailParticle.Play(); // Play the trail particle effect

            
        }
    }


     void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); // find the index of the floor layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the floor layer
        {
          
             TrailParticle.Stop(); // Stop the trail particle effect when the player exits the floor collider
            
        }
    }
}
