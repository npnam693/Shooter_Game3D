
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.SocialPlatforms.Impl;


namespace CompleteProject
{
    public class WinStatus : MonoBehaviour
    {
        // Start is called before the first frame update
        GameOverManager gameOverManager;        // The player's score.

        Text text;                      // Reference to the Text component.

        float value;
        void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();
            gameOverManager = GetComponentInParent<GameOverManager>();
            // Reset the score.
        }


        void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            value = gameOverManager.getNumUserWin();
            text.text = value + "/2";
        }
    }
}