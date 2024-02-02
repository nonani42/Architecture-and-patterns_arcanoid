using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystems : MonoBehaviour
{ 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            RestartGame();
    }

    private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
