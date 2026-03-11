using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    InputAction moveAction;
    Rigidbody2D rb;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>(); // Find the SurfaceEffector2D in the scene
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        BoostPlayer();
    }


    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
        rb.AddTorque(torqueAmount); // Apply torque based on the horizontal input
        else if (moveVector.x > 0)
        rb.AddTorque(-torqueAmount); // Apply torque in the opposite direction for positive input
    }

    void BoostPlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.y > 0)
           surfaceEffector.speed = boostSpeed; // Set the speed of the SurfaceEffector2D to boostSpeed when the vertical input is positive
        else
           surfaceEffector.speed = baseSpeed; // Set the speed of the SurfaceEffector2
    }
}
