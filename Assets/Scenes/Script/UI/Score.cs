using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int playerScore = 0;
    private int enemyrScore = 0;
    public void IncrementPlayerScore()
    {
        playerScore++;
        UpdateScoreText();
    }

    public void IncrementEnemyScore()
    {
        enemyrScore++;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        GetComponent<Text>().text=playerScore+":"+enemyrScore;
    }

    public void Reset()
    {
        playerScore = 0;
        enemyrScore = 0;
    }
}
