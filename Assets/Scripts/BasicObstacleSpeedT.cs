using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleSpeedT : MonoBehaviour
{
    public float speed = 0;
    private float startingY;
    public int layer;
    public float distance;
    public GameObject raycastpoint;
    public BasicObstacleSpeedS SideClone;
    // Start is called before the first frame update
    void Start()
    {

        raycastpoint = gameObject.transform.Find("edgepoint").gameObject;
        startingY = transform.localPosition.y;
        if (gameObject.name.Contains("Iceberg"))
        {
            SideClone = GameObject.Find("STTOM").GetComponent<STTObjectManager>().CreateIcebergS(speed * 0.5873f, layer, gameObject);
        }
        else if(gameObject.name.Contains("Megaiceberg"))
        {
            SideClone = GameObject.Find("STTOM").GetComponent<STTObjectManager>().CreateMegaIcebergS(speed * 0.5873f, layer, gameObject);
        }
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(raycastpoint.transform.position, Vector2.down);


        foreach (RaycastHit2D c in hit)
        {
            if (c.collider is not null && c.collider.gameObject.CompareTag("PlayerTWide"))
            {
                
                distance = c.distance;
            }

        }

        transform.position -= new Vector3(0, 0.01f * speed, 0) * Time.deltaTime * 50;

        if(Mathf.Abs(transform.localPosition.y - startingY) > 13)
        {
            SideClone.hasGuideObj = 0;
            Destroy(gameObject);
        }
    }
}
