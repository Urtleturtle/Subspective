using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleSpeedS : MonoBehaviour
{
    public float speed = 0;
    private float startingX;
    public int layer;
    public Transform guideObj;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.localPosition.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(guideObj is null)
        {
            transform.position -= new Vector3(0.01f * speed, 0, 0);
        }
        else
        {
            transform.localPosition = new Vector3((guideObj.localPosition.y)/9.2f * 5.5f, transform.localPosition.y, transform.localPosition.z);
        }

        if (Mathf.Abs(transform.localPosition.x - startingX) > 9)
        {
            Destroy(gameObject);
        }
    }
}
