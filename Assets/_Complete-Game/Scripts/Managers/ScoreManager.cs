using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.
        Text scoreText;

        void Awake ()
        {
            // Set up the reference.
            scoreText = GetComponent<Text>();
            // Reset the score.
            score = 0;
        }

        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            scoreText.text = "Score: " + score;
        }
        
    }
}