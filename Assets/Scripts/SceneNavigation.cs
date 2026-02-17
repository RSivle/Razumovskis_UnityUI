using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public AudioSource clickSound;

    // Atpakaļ uz MainMenu
    public void GoToMainMenu()
    {
        if (clickSound != null) clickSound.Play();
        SceneManager.LoadScene(0); // index 0 = MainMenu
    }

    // Uz CharacterScene
    public void GoToCharacterScene()
    {
        if (clickSound != null) clickSound.Play();
        SceneManager.LoadScene(1); // index 1 = CharacterScene
    }
}
