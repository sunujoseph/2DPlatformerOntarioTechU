using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //subscribe to event
        ScoreManager.instance.OnScoreChange += ScoreManger_OnScoreChange;
    }

    private void ScoreManger_OnScoreChange(object sender, System.EventArgs e)
    {
        scoreText.text = ScoreManager.instance.playerScore.ToString();
    }
}
