using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;

    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if(PlayerInfo.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;
        Debug.Log("Oyun Bitti");
    }
}
