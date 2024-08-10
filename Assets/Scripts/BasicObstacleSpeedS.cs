using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObstacleSpeedS : MonoBehaviour
{
    public float speed = 0;
    private float startingX;
    public int layer;
    public Transform guideObj = null;
    public int hasGuideObj;
    [SerializeField]
    GameObject raycastpoint;
    public float distance;
   
    // Start is called before the first frame update
    void Start()
    {
        raycastpoint = gameObject.transform.Find("edgepoint").gameObject;
        startingX = transform.localPosition.x;
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(raycastpoint.transform.position, Vector2.left);
    }
    void FixedUpdate()
    {
        if(hasGuideObj == 0)
        {
            Destroy(gameObject);
        }
        
        RaycastHit2D[] hit = Physics2D.RaycastAll(raycastpoint.transform.position, Vector2.left);


        foreach (RaycastHit2D c in hit)
        {
            if (c.collider is not null && c.collider.gameObject.CompareTag("PlayerSWide"))
            {
                distance = c.distance;
            }

        }

        if (hasGuideObj == 1 && guideObj.GetComponent<BasicObstacleSpeedT>().distance > 0.1f)
        {
            if (distance > guideObj.GetComponent<BasicObstacleSpeedT>().distance * 0.5873f)
            {
                speed += 0.005f;
            }
            else if (distance < guideObj.GetComponent<BasicObstacleSpeedT>().distance * 0.5873f)
            {
                speed -= 0.005f;
            }
        }
        

        transform.position -= new Vector3(0.01f * speed, 0, 0) * Time.deltaTime * 50;
        
       
        

        if (Mathf.Abs(transform.localPosition.x - startingX) > 12)
        {
            Destroy(gameObject);
        }
    }
    
}
