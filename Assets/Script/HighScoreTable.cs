using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HighScoreTable : MonoBehaviour
{
    private Transform inputStore, inputTemplate;
    public GameObject scoreInput, nameInput;

    private List<HighScoreInput> highScoreList;
    private List<Transform> highscoreTransformList;

    private void Awake()
    {
        inputStore = transform.Find("highscoreStore");
        inputTemplate = inputTemplate.Find("highscoreInput");

        inputTemplate.gameObject.SetActive(false);

        highScoreList = new List<HighScoreInput>() {

            new HighScoreInput{score= 123, name= "Mai"},
            new HighScoreInput{score= 12453, name= "Maui"},
            new HighScoreInput{score= 134523, name= "Main"},
            new HighScoreInput{score= 12333, name= "Maiy"},
        };




        highscoreTransformList = new List<Transform>();
        foreach (HighScoreInput highScoreinput in highScoreList)
        {
            createHighScoreInput(highScoreinput, inputStore , highscoreTransformList);
        }

    }

    private void createHighScoreInput(HighScoreInput highScoreinput, Transform container, List<Transform> transformsList)
    {
        float templateHight = 20f;

        Transform inputTransform = Instantiate(inputStore, container);
        RectTransform inputRectTransform = inputTransform.GetComponent<RectTransform>();
        inputRectTransform.anchoredPosition = new Vector2(0, -templateHight * transformsList.Count);
        inputTemplate.gameObject.SetActive(true);

        int rank = transformsList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }



        inputTransform.Find("numberSTT").GetComponent<Text>().text = rankString;

        string point = scoreInput.GetComponent<Text>().text.ToString();
        inputTransform.Find("nameInput").GetComponent<Text>().text = point;

        string name = nameInput.GetComponent<Text>().text.ToString();
        inputTransform.Find("scoreInput").GetComponent<Text>().text = name;

        transformsList.Add(inputTransform);
    }

    private class HighScoreInput
    {
        public int score;
        public string name;
    }
}
