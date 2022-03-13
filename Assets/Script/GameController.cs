using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject m_sheep,m_tutorial,m_scoreUI,m_panelEndGame;
    public GameObject[] m_wolfs;

    private TextMeshProUGUI m_scoreUI_TMP;
    public TextMeshProUGUI m_finalScoreUI_TMP;
    private int m_score;


    private bool m_isStarted;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;

        m_isStarted = false;
        m_score = 0;
        m_scoreUI_TMP = m_scoreUI.GetComponent<TextMeshProUGUI>();
        m_wolfs = GameObject.FindGameObjectsWithTag("enemy");

        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start game when click on screen
        if (!m_isStarted && Input.GetMouseButtonDown(0))
        {
            // avtive & deactive UI
            m_scoreUI.SetActive(true);
            m_tutorial.SetActive(false);

            // play enemy
            foreach (GameObject wolf in m_wolfs)
            {
                wolf.GetComponent<WolfController>().StartThrowingBoom();
            }
            m_sheep.GetComponent<PlayerController>().StartPlayer();

            Time.timeScale = 1;

            //set value
            m_isStarted = true;
        }
    }

    public void GOTOMousePos(GameObject i_obj, float i_moveSpeed, float i_z)
    {
        Vector3 mousePOS;
        // get mouse position 
        mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // set i_obj to mouse position
        i_obj.transform.position = Vector3.Lerp(i_obj.transform.position, mousePOS, i_moveSpeed * 0.1f);
    }


    public void endGame()
    {
        audio.Play();

        // stop Time Scale
        Time.timeScale = 0;

        // set enemy
        foreach (GameObject wolf in m_wolfs)
        {
            wolf.GetComponent<WolfController>().StopThrowingBoom();
        }
        m_sheep.GetComponent<PlayerController>().StopPlayer();

        // set total score
        m_finalScoreUI_TMP.SetText("Final Score: " + m_score);

        // active & deactive UI
        m_panelEndGame.SetActive(true);
        m_scoreUI.SetActive(false);

        //debug
        Debug.Log("end Game");
    }

    public void AddScore()
    {
        // plus score & refresh score UI
        m_score++;
        m_scoreUI_TMP.SetText("Score: " + m_score);
    }

    public void Restart()
    {
        // reload screen
        SceneManager.LoadScene(0);
        Debug.Log("load Scene");
    }
}
