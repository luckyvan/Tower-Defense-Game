using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

	void Update () {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            if (!GameIsOver)
            {
                EndGame();
            }
        }
	}

    private void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
