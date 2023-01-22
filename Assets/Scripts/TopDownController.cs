using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rotationVelocity = 0;
    bool boundl, boundr;
    public int depth;
    public int layer;
    public TextMeshProUGUI LoseText;
    public Button TryAgainButton;

    [SerializeField]
    private float layerbound1, layerbound2;

    void Start()
    {
        layer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rotationVelocity > 0 && rb.rotation >= 26 || rotationVelocity < 0 && rb.rotation <= -30)){
            rb.MoveRotation(rb.rotation + rotationVelocity);
            rb.velocity = new Vector2(-(.1f * rb.rotation), 0);
        }
        else
        {
            rotationVelocity = 0;
        }
        //cap Rvelocity to 1 or -1
        if (Input.GetKey(KeyCode.A) && !boundl)
        {
            if (rotationVelocity < .7f)
            {
                rotationVelocity = .3f;
            }
            boundr = false;
        }
        else if (Input.GetKey(KeyCode.D) && !boundr)
        {
            if (rotationVelocity > -.7f)
            {
                rotationVelocity = -.3f;
            }
            boundl = false;
        }
        else
        {
            if(rb.rotation < -1 || rb.rotation > 1)
            {
                rotationVelocity += -rb.rotation/10000.0f;
            }
            else
            {
                rb.MoveRotation(Mathf.Lerp(rb.rotation, 0, 2f));
                rotationVelocity = Mathf.Lerp(rotationVelocity, 0, 2f);
            }
        }

        
        //depth to z position

        if(depth <= 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }

        if(transform.localPosition.x <= layerbound1)
        {
            layer = 1;
        }
        else if(transform.localPosition.x <= layerbound2)
        {
            layer = 2;
        }
        else
        {
            layer = 3;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.rotation > 0)
        {
            boundl = true;
        }
        else
        {
            boundr = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopObstacle") && depth <= 2)
        {
            LoseText.enabled = true;
            TryAgainButton.gameObject.SetActive(true);
            StartCoroutine(EndGame());


        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }

}
