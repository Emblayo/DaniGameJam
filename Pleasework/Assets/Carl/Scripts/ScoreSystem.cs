using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    public float score;
    public float scoreMultiplier = 1;

    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * scoreMultiplier;
        tmp.text = "SCORE: " + Mathf.RoundToInt(score);
    }
}
