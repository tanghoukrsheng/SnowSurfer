using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour


{
    [SerializeField] float delayBeforeReload = 2f;
    [SerializeField] ParticleSystem winParticle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player"); // find the index of the player layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the player layer
        {
            print("You win!");
            winParticle.Play(); // Play the win particle effect
            Invoke("reloadScene", delayBeforeReload); // Call the reloadScene method after a delay of 2 seconds
        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the current scene to restart the game
    }
}
