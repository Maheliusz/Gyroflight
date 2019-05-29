using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button exit, retry, menu;
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(this.Exit);
        retry.onClick.AddListener(this.Retry);
        menu.onClick.AddListener(this.Menu);
    }
    
    public void PlayerDied()
    {
        retry.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        exit.gameObject.SetActive(false);
    }

    void Retry()
    {
        SceneManager.LoadScene("TMP1_Scene");
    }

    void Exit()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
