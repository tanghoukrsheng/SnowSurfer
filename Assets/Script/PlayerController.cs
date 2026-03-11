using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] ParticleSystem powerupParticle;
    InputAction moveAction;
    Rigidbody2D rb;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector;

    int powerUpCount; // Variable to count the number of active powerups

     bool canControl = true; // Flag to determine if the player can control the character

     float previousRotation; // Variable to store the previous rotation of the player
     float totalRotation;
     int flipCount ; // Variable to count the number of flips performed by the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindFirstObjectByType<SurfaceEffector2D>(); // Find the SurfaceEffector2D in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
        RotatePlayer();
        BoostPlayer();
        CalculateFlips();
        }

    }

    public int getFlipCount()
    {
        return flipCount; // Method to get the current flip count, can be called from other scripts
    }

    public void DisableControl()
    {
        canControl = false; // Method to disable player control, can be called from other scripts
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

    void CalculateFlips()
    {
    float currentRotation = transform.rotation.eulerAngles.z;

    totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation); // Calculate the change in rotation since the last frame and add it to the total rotation
    
    if(totalRotation > 340f || totalRotation < -340f) // Check if the total rotation exceeds 360 degrees in either direction
    {
        flipCount++; // Increment the flip count
        totalRotation = 0f; // Reset the total rotation for the next flip
    }

    previousRotation = currentRotation;
    }


    public void ActivatePowerup(PowerupSC powerup)

    {
       
        powerUpCount++;
        powerupParticle.Play(); // Play the powerup particle effect when a powerup is activated
        if (powerup.GetPowerupType == "speed")
        {
            baseSpeed += powerup.GetValueChange; // Increase the base speed by the value defined in the PowerupSC
            boostSpeed += powerup.GetValueChange; // Increase the boost speed by the value defined in the PowerupSC
           
        }
        
        else if(powerup.GetPowerupType == "torque")
        {
            torqueAmount += powerup.GetValueChange; // Increase the torque amount by the value defined in the PowerupSC
        }


    }

   public void DeactivatePowerup(PowerupSC powerup)
    {

        powerUpCount--;
        if(powerUpCount == 0)
        {
            powerupParticle.Stop();
        }

        if (powerup.GetPowerupType == "speed")
        {
            baseSpeed -= powerup.GetValueChange; // Decrease the base speed by the value defined in the PowerupSC
            boostSpeed -= powerup.GetValueChange; // Decrease the boost speed by the value defined in the PowerupSC
        }
        else if (powerup.GetPowerupType == "torque")
        {
            torqueAmount -= powerup.GetValueChange; // Decrease the torque amount by the value defined in the PowerupSC
        }
       
    }

}
