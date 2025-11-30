using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
