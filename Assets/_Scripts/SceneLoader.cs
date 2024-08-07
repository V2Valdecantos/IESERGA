using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadExamineScene()
    {
        SceneManager.LoadScene(SceneNames.examine_scene);
    }

    public void LoadConversationScreen()
    {
        SceneManager.LoadScene(SceneNames.conversation_scene);
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(SceneNames.title_screen);
    }

    public void LoadResultsScreen()
    {
        SceneManager.LoadScene(SceneNames.end_screen);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene(SceneNames.win_screen);
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene(SceneNames.lose_screen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


