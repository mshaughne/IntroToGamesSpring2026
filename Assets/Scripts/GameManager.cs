using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coinsObtained = 0;
    public TextMeshProUGUI coinsText;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PickUpCoin()
    {
        // increase our number of coins by 1
        coinsObtained++;
        // update text to match
        coinsText.text = "Coins: " + coinsObtained;

        if (coinsObtained >= 3)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
