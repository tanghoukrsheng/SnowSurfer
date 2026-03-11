using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas; 
    [SerializeField] GameObject DinoSprite; 
    [SerializeField] GameObject FrogSprite; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; 
    }

    // Update is called once per frame

    void BeginGame()
    {
        Time.timeScale = 1f; 
        scoreCanvas.SetActive(true); // Activate the score canvas when the game starts
        gameObject.SetActive(false); // Deactivate the character selection menu
    }

    public void ChooseFrog()
    {
        FrogSprite.SetActive(true); // Activate the character sprite when a character is chosen
        BeginGame(); 
    }

    public void ChooseDino()
    {
        DinoSprite.SetActive(true); // Activate the character sprite when a character is chosen
        BeginGame(); 
    }
   
}
