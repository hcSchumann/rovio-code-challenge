using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameStartButton : MonoBehaviour
{
    private string GameSceneName = "GameScene";

    public void OnClick()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
