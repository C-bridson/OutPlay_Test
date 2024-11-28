using TMPro;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject panel; //the parent of all UI elements

    [SerializeField]
    private GameObject endGameMenu;

    [SerializeField]
    private GameObject startGameMenu;

    [SerializeField]
    private TMP_Text endGameText;

    [SerializeField]
    private Manager manager;


    private void Awake()
    {
        manager = FindObjectOfType<Manager>();
        panel = this.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        endGameMenu.SetActive(false);
        startGameMenu.SetActive(true);

    }

    /// <summary>
    /// Display the appropriate screen based on game state
    /// change text to reflect state
    /// </summary>
    /// <param name="gameState"></param>
    public void ShowEndScreen(string gameState)
    {
      
        if (gameState == "Win")
        {
            
            panel.SetActive(true);
            endGameText.text = "Congrats";
            endGameMenu.SetActive(true);
        }
        else if (gameState == "Lose")
        {
         
            panel.SetActive(true);
            endGameText.text = "Better luck next time";
            endGameMenu.SetActive(true);
        }
    }
    
    /// <summary>
    /// start the game on press, allow player to move, hide UI
    /// </summary>
    public void StartGame()
    {
        manager.CanMove = true;
        startGameMenu.SetActive(false);
        panel.SetActive(false);
    }

    /// <summary>
    /// Hide UI, Start a new game by calling manager.
    /// </summary>
    public void RestartGame()
    {
        endGameMenu.SetActive(false);
        panel.SetActive(false);

        manager.NewGame();

    }

}

