using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchScoreScript : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    float finalScore;
    ScoreSystem scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreSystem>();
        finalScore = scoreScript.score;
        finalScoreText.text = "SCORE: " + Mathf.RoundToInt(finalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
