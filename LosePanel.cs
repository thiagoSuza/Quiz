using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private Text score;


    private void OnEnable()
    {
        score.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        Time.timeScale = 0f;        
    }


    public void Reload()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
