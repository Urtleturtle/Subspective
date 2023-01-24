using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTObjectManager : MonoBehaviour
{

    public GameObject[] Icebergs;
    public GameObject[] Megaicebergs;
    public GameObject TopSub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("SideObstacle")){
            if (g.GetComponent<BasicObstacleSpeedS>().layer == TopSub.GetComponent<TopDownController>().layer)
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
                g.GetComponent<PolygonCollider2D>().enabled = true;
            }
            else
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
                g.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
    }

    public void CreateIcebergS(float speed, int layer, GameObject guide)
    {
        GameObject Icebergclone = Instantiate(Icebergs[Random.Range(0, Icebergs.Length - 1)], gameObject.transform.parent.transform, false);
        Icebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        Icebergclone.GetComponent<BasicObstacleSpeedS>().speed = speed;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().layer = layer;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().guideObj = guide.transform;
    }
    public void CreateMegaIcebergS(float speed, int layer, GameObject guide)
    {
        GameObject Megaicebergclone = Instantiate(Megaicebergs[Random.Range(0, Megaicebergs.Length - 1)], gameObject.transform.parent.transform, false);
        Megaicebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().speed = speed;
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().layer = layer;
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().guideObj = guide.transform;
    }
}
