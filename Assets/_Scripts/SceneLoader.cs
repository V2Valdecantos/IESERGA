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


