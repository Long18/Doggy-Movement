using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerSheep.Scoreboard 
{
    public class ScoreInputUI : MonoBehaviour
    {
        [SerializeField]private Text inputName = null;
        [SerializeField]private Text inputScore = null;

        public void Initialise(ScoreboardInput scoreboardInput)
        {
            inputName.text = scoreboardInput.inputName;
            inputScore.text = scoreboardInput.inputScore.ToString();
        }
    }
}

