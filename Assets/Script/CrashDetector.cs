using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayBeforeReload = 2f;
    [SerializeField] ParticleSystem crashParticle;
  void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); // find the index of the floor layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the floor layer
        {
           print("You lost!");
           crashParticle.Play(); // Play the crash particle effect
           Invoke("reloadScene", delayBeforeReload); // Call the reloadScene method after a delay of 2 seconds
        }
    }


    void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the current scene to restart the game
    }
    
}
