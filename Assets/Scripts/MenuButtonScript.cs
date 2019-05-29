using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public Button play, exit;

    private void Start()
    {
        play.onClick.AddListener(this.Play);
        exit.onClick.AddListener(this.Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene("TMP1_Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
