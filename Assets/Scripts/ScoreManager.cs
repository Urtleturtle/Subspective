using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using CameraShake;
public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreBoard;
    private int counterTimer;
    public TextMeshProUGUI LoseText;
    public TextMeshProUGUI Highscore;
    public Button TryAgainButton;
    public TextMeshProUGUI LoseScorescreen;
    public Image FadeScreen;
    public GameObject SubS, SubT;

    // Start is called before the first frame update
    void Start()
    {
        counterTimer = 200;
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
            counterTimer = 200;
            score++;
            
        }
        
    }
    
    public void EndGame()
    {
        LoseText.enabled = true;
        TryAgainButton.gameObject.SetActive(true);
        LoseScorescreen.enabled = true;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            print("Highscore");
            PlayerPrefs.SetInt("HighScore", score);
            LoseScorescreen.text = "New High Score!\n";
        }
        else {
            LoseScorescreen.text = "";
        }

        if (score == 1)
        {
            LoseScorescreen.text += "You scored\n" + score + " point";
        }
        else
        {
            LoseScorescreen.text += "You scored\n" + score + " points";
        }
        
        CameraShaker.Presets.Explosion2D();
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        float speed = GameObject.FindGameObjectWithTag("TopObstacle").GetComponent<BasicObstacleSpeedT>().speed;
        LeanTween.moveLocalY(FadeScreen.gameObject, 0, 0.5f).setIgnoreTimeScale(true);
        
        SubS.GetComponent<Animator>().SetBool("isDead", true);
        SubS.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        SubT.GetComponent<Animator>().SetInteger("Depth", 4);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SideObstacle"))
        {
            g.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
        while (speed > 0.2f)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("TopObstacle"))
            {
                
                BasicObstacleSpeedT c = g.GetComponent<BasicObstacleSpeedT>();
                c.speed = speed;
                g.GetComponent<PolygonCollider2D>().isTrigger = false;

            }
            speed -= speed / 20f;

            yield return new WaitForSeconds(0.1f);
        }


        
        Time.timeScale = 0;

    }
}
