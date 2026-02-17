using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource buttonClickSound;

    
    public void StartGame()
    {
        PlayButtonClick();
        
        SceneManager.LoadScene(1);
    }

    
    public void QuitGame()
    {
        PlayButtonClick();
        Application.Quit();
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlayButtonClick()
    {
        if (buttonClickSound != null)
            buttonClickSound.Play();
    }
}