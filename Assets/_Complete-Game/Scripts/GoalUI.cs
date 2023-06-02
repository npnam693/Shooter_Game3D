using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoalUI : MonoBehaviour
{
    public static int numGoal;        // The player's score.
    Text goalText;

    void Awake()
    {
        // Set up the reference.
        goalText = GetComponent<Text>();
        // Reset the score.
        numGoal = 0;
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        goalText.text = "Goal: " + numGoal;
    }
}
