using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameEnded;

	void Update () {
        if (PlayerStats.Lives <= 0)
        {
            if (!gameEnded)
            {
                EndGame();
            }
        }
	}

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("GAME OVER!!!!!!");
    }
}
