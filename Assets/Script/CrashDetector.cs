using UnityEngine;

public class CrashDetector : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor"); // find the index of the floor layer
        if (collision.gameObject.layer == layerIndex) // Check if the collided object is on the floor layer
        {
            print("You lost!");
        }
    }
}
