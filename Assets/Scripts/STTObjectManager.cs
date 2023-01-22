using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTObjectManager : MonoBehaviour
{

    public GameObject[] Icebergs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateIcebergS(float speed, int layer)
    {
        GameObject Icebergclone = Instantiate(Icebergs[Random.Range(0, Icebergs.Length - 1)], gameObject.transform.parent.transform, false);
        Icebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        Icebergclone.GetComponent<BasicObstacleSpeedS>().speed = speed;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().layer = layer;
    }
}
