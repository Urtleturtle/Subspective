using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAgain()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
