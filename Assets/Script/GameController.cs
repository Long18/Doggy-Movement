using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pnlEndGame, pnlStartMenu, pnlName, pnlHighScore ;
    public Button btnRestart, btnStart, btnName;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    public Text txtPoint;
    private int gamePoint;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        pnlStartMenu.SetActive(true);
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        pnlStartMenu.SetActive(false);
        Time.timeScale = 1;

    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text =  gamePoint.ToString();
    }

    public void ButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void ButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void ButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        audio.Play();
        Time.timeScale = 0;
        pnlHighScore.SetActive(true);
    }
}
