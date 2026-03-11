using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    PlayerController playerController;
    int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>(); // Find the PlayerController script in the scene
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore(); // Call the method to display the score every frame
    }



    void DisplayScore()
    {
        // This method can be used to display the score based on the player's flips or other actions   
        int flipScore = playerController.getFlipCount() * 100; 
        scoreText.text = "Score : " + flipScore; // Update the score text with the current score
        
    }
}
