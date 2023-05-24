using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BtnActions(int x)
    {
        PlayerPrefs.SetInt("SelectedTheme", x);
        SceneManager.LoadScene(1);
    }

    
}
