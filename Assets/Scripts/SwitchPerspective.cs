using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPerspective : MonoBehaviour
{

    public GameObject sideview, topdownview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchV()
    {
        if(sideview.transform.position == new Vector3(0, 0, 0))
        {
            sideview.transform.position = topdownview.transform.position;
            topdownview.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            topdownview.transform.position = sideview.transform.position;
            sideview.transform.position = new Vector3(0, 0, 0);
        }
    }
}
