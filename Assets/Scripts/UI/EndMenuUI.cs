using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenuUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.instance != null)
        {
            int currentScore = ScoreManager.instance.playerScore;
            scoreText.text = currentScore.ToString();
            Destroy(ScoreManager.instance.gameObject);
        }
    }

    
}
