using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadExamineScene()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(SceneNames.examine_scene);
    }

    public void LoadConversationScreen()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(SceneNames.conversation_scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


