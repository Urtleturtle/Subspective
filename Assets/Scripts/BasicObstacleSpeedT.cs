using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleSpeedT : MonoBehaviour
{
    public float speed = 0;
    private float startingY;
    public int layer;
    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.localPosition.y;
        if (gameObject.name.Contains("Iceberg"))
        {
            GameObject.Find("STTOM").GetComponent<STTObjectManager>().CreateIcebergS(speed/9.2f* 5.5f, layer, gameObject);
        }
        else if(gameObject.name.Contains("Megaiceberg"))
        {
            GameObject.Find("STTOM").GetComponent<STTObjectManager>().CreateMegaIcebergS(speed / 9.2f * 5.5f, layer, gameObject);
        }
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0.01f * speed, 0);

        if(Mathf.Abs(transform.localPosition.y - startingY) > 13)
        {
            Destroy(gameObject);
        }
    }
}
