using System.IO;
using UnityEngine;

namespace RunnerSheep.Scoreboard
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardInput = 5;
        [SerializeField] private Transform highscoreHolder = null;
        [SerializeField] private GameObject socreboardInput = null;

        [Header("Test")]
        [SerializeField] ScoreboardInput testInputData = new ScoreboardInput();

        private string SavePath => $"{Application.persistentDataPath}/highsocre.json";

        private void Start()
        {
            ScoreSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
        }

        [ContextMenu("Add Text Input ")]
        public void AddText()
        {
            addEntry(testInputData);
        }

        public void addEntry(ScoreboardInput scoreboardInput)
        {
            ScoreSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //for (int i = 0; i < savedScores.highsocre.Count; i++)
            //{
            //    if(scoreboardInput.inputScore > savedScores.highsocre[i].inputScore)
            //    {
            //        savedScores.highsocre.Insert(i, scoreboardInput);
            //        scoreAdded = true;
            //        break;
            //    }
            //}

            if(!scoreAdded && savedScores.highsocre.Count < maxScoreboardInput)
            {
                savedScores.highsocre.Add(scoreboardInput);
            }

            if(savedScores.highsocre.Count > maxScoreboardInput)
            {
                savedScores.highsocre.RemoveRange(maxScoreboardInput, savedScores.highsocre.Count - maxScoreboardInput);
            }

            UpdateUI(savedScores);
            SavedScore(savedScores);
        }

        private void UpdateUI(ScoreSaveData scoreSaveData)
        {
            foreach (Transform child in highscoreHolder)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardInput highscore in scoreSaveData.highsocre)
            {
                Instantiate(socreboardInput, highscoreHolder).GetComponent<ScoreInputUI>().Initialise(highscore);
            }
        }

        private ScoreSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreSaveData();
            }

            using(StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreSaveData>(json);
            }
        }

        private void SavedScore(ScoreSaveData scoreSaveData)
        {
            using(StreamWriter stream  = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreSaveData, true);
                stream.Write(json);
            }
        }
    }
}

