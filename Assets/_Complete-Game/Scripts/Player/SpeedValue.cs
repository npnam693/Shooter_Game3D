
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.SocialPlatforms.Impl;

namespace CompleteProject
{
    public class SpeedValue : MonoBehaviour
    {
        PlayerMovement playerMovement;        // The player's score.

        Text text;                      // Reference to the Text component.

        float value;
        void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();
            playerMovement = GetComponentInParent<PlayerMovement>();
            // Reset the score.
        }


        void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            value = playerMovement.speed;
            text.text = "Speed: " + value;
        }
    }
}