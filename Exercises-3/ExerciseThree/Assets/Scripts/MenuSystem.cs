using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class MenuSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject endGameMenu;
    private TextMeshProUGUI TextMeshProUGUI;

    [SerializeField]
    private GameObject startGameMenu;

    private void Start()
    {
        endGameMenu.SetActive(false);
        startGameMenu.SetActive(true);
    }


    public void ShowEndScreen(string gameState)
    {
        if (gameState == "win")
        {
            endGameMenu.SetActive(true);
            TextMeshProUGUI.text = "Congrats";
        }
        else if (gameState == "lose")
        {
            endGameMenu.SetActive(true);
            TextMeshProUGUI.text = "better luck next time";
        }
    }


    public void RestartGame()
    {
        endGameMenu.SetActive(false);
        startGameMenu.SetActive(true);
    }

}

