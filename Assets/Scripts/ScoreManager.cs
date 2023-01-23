using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreBoard;
    private int counterTimer;
    public TextMeshProUGUI LoseText;
    public Button TryAgainButton;
    public TextMeshProUGUI LoseScorescreen;

    // Start is called before the first frame update
    void Start()
    {
        counterTimer = 50;
        score = 0;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //scoreboard script
        scoreBoard.text = "Score: " + score;
        counterTimer--;
        if (counterTimer < 0)
        {
            counterTimer = 50;
            score++;
        }

    }
    
    public void EndGame()
    {
        LoseText.enabled = true;
        TryAgainButton.gameObject.SetActive(true);
        LoseScorescreen.enabled = true;
        LoseScorescreen.text = "You scored\n" + score + " points";
        StartCoroutine(EG());

    }
    IEnumerator EG()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }
}
