using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 100f;

    public const string HighScoreKey = "HighScore";
    private float score;

   void Update()
   {
       score += Mathf.FloorToInt(Time.deltaTime * scoreMultiplier);
       
       scoreText.text = score.ToString();
   }

   private void OnDestroy()
   {
       int currentHighScore = PlayerPrefs.GetInt(HighScoreKey,0);

       if (score > currentHighScore)
       {
           PlayerPrefs.SetInt(HighScoreKey,(int) score);
       }
   }
}
