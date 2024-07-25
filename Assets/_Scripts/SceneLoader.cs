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

    public void QuitGame()
    {
        Application.Quit();
    }
}

public class SceneNames
{
    public static string examine_scene = "ExamineScene";
    public static string conversation_scene = "MainScene";
    public static string title_screen = "TitleScreen";
    public static string end_screen = "EndScreen";
}
