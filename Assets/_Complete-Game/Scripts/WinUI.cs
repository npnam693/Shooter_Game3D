using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    // Update is called once per frame
    void Update()
    {
        if(GoalUI.numGoal == 3)
        {
            winUI.SetActive(true);
        }
    }
}
