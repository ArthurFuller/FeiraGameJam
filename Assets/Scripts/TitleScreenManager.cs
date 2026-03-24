using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject creditsCanvas;

    void Start()
    {
        titleCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }


    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        titleCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void Menu()
    {
        creditsCanvas.SetActive(false);
        titleCanvas.SetActive(true);
    }
}
