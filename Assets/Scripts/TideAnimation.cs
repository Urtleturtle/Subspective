using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideAnimation : MonoBehaviour
{
    public GameObject[] waves;
    private GameObject edgeWave, middleWave;
    public float waveoffset, speed;
    // Start is called before the first frame update
    void Start()
    {
        middleWave = waves[0];
        edgeWave = waves[0];
        speed = 1.8f;

        for(int i = 0; i < waves.Length; i++)
        {
            if(i == 0)
            {
                waves[0].transform.localPosition = new Vector3(0, 3.385f, -2f);
            }
            else
            {
                waves[i].transform.localPosition = new Vector3(i *waves[0].transform.Find("Wave").GetComponent<SpriteRenderer>().sprite.rect.width/20.0f , 3.385f, -2f);
            }
        }
        waveoffset = waves[0].transform.Find("Wave").GetComponent<SpriteRenderer>().sprite.rect.width/20.0f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        foreach(GameObject waveobj in waves)
        {
            waveobj.transform.position -= new Vector3(0.01f * speed,0,0f);
            if(Mathf.Abs(waveobj.transform.localPosition.x) < Mathf.Abs(middleWave.transform.localPosition.x))
            {
                middleWave = waveobj;
            }
            else
            {
                if(waveobj.transform.localPosition.x < edgeWave.transform.localPosition.x)
                {
                    edgeWave = waveobj;
                }
            }
        }

        if (middleWave.transform.localPosition.x < 0 && edgeWave != middleWave)
        {
            edgeWave.transform.localPosition += new Vector3(3f * waveoffset, 0, 0);
        }
        
        
    }
}
