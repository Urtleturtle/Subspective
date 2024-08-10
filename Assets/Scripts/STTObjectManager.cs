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
            BasicObstacleSpeedS c = g.GetComponent<BasicObstacleSpeedS>();
            if (c.layer == (int)TopSub.GetComponent<TopDownController>().layer)
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
                g.GetComponent<SpriteRenderer>().color = Color.white;
                //make it so that if the layer is like 1.5 or soemthing than the obstacle has no collider and is transparent kinda
                /*
                if(g.GetComponent<BasicObstacleSpeedS>().layer == 1.5f)
                {
                    
                }
                else if (g.GetComponent<BasicObstacleSpeedS>().layer == 2.5f)
                {

                }
                else
                {
                    g.GetComponent<PolygonCollider2D>().enabled = true;
                }
                */
                g.GetComponent<PolygonCollider2D>().enabled = true;

            }
            else if (c.layer < (int)TopSub.GetComponent<TopDownController>().layer && (int)TopSub.GetComponent<TopDownController>().layer - c.layer == 1)
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
                g.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255,60);
                g.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
                g.GetComponent<PolygonCollider2D>().enabled = false;
            }
            
        }
    }

    public BasicObstacleSpeedS CreateIcebergS(float speed, int layer, GameObject guide)
    {
        GameObject Icebergclone = Instantiate(Icebergs[Random.Range(0, Icebergs.Length - 1)], gameObject.transform.parent.transform, false);
        if(layer < 2)
        {
            Icebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
        }
        else if (layer > 2)
        {
            Icebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.7f);
        }
        else
        {
            Icebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }

        Icebergclone.GetComponent<BasicObstacleSpeedS>().speed = speed;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().layer = layer;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().guideObj = guide.transform;
        Icebergclone.GetComponent<BasicObstacleSpeedS>().hasGuideObj = 1;
        return Icebergclone.GetComponent<BasicObstacleSpeedS>();
    }
    public BasicObstacleSpeedS CreateMegaIcebergS(float speed, int layer, GameObject guide)
    {
        GameObject Megaicebergclone = Instantiate(Megaicebergs[Random.Range(0, Megaicebergs.Length - 1)], gameObject.transform.parent.transform, false);
        if (layer < 2)
        {
            Megaicebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
        }
        else if (layer > 2)
        {
            Megaicebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.7f);
        }
        else
        {
            Megaicebergclone.transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }

        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().speed = speed;
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().layer = layer;
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().guideObj = guide.transform;
        Megaicebergclone.GetComponent<BasicObstacleSpeedS>().hasGuideObj = 1;
        return Megaicebergclone.GetComponent<BasicObstacleSpeedS>();
    }
}
