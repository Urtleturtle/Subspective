using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class SwitchPerspective : MonoBehaviour
{

    public GameObject sideview, topdownview;
    public bool modeSide;
    public Image joystick;
    public Sprite S, T;
    // Start is called before the first frame update
    void Start()
    {
        joystick.sprite = T;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchV()
    {
        if (sideview.transform.position == new Vector3(0, 0, 0))
        {
            sideview.transform.position = topdownview.transform.position;
            topdownview.transform.position = new Vector3(0, 0, 0);
            modeSide = false;
            joystick.sprite = T;
            topdownview.transform.Find("SubmarineT").GetComponent<PlayerInput>().enabled = true;
            sideview.transform.Find("SubmarineS").GetComponent<PlayerInput>().enabled = false;
        }
        else
        {
            topdownview.transform.position = sideview.transform.position;
            sideview.transform.position = new Vector3(0, 0, 0);
            modeSide = true;
            joystick.sprite = S;
            topdownview.transform.Find("SubmarineT").GetComponent<PlayerInput>().enabled = false;
            sideview.transform.Find("SubmarineS").GetComponent<PlayerInput>().enabled = true;
        }
    }
}
