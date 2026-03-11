using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player"); // find the index of the player layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the player layer
        {
            print("You win!");
        }
    }
}
