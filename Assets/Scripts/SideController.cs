using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SideController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxspd;
    public float waterline = 3.26f;
    public SpriteRenderer sr;
    public Animator SubT;
    public float[] depthLvls = new float[3];

    public PlayerInput playerInput;
    public GameObject viewButton;
    public ScoreManager scoreManager;
    public TextMeshProUGUI debug;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, 0);
        waterline = 3.26f;
        rb.gravityScale = 0;
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //debug.text = playerInput.actions["Move"].ReadValue<Vector2>().ToString();


        if (transform.localPosition.y <= waterline)
        {
            //rb.gravityScale = Mathf.Lerp(rb.gravityScale, 0, 0.5f); 
            rb.gravityScale = 0;
            
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity += new Vector2(0, -0.03f);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rb.velocity += new Vector2(0, 0.03f);
            }
            else if (playerInput.actions["Move"].ReadValue<Vector2>().y < 0 && viewButton.GetComponent<SwitchPerspective>().modeSide)
            {
                rb.velocity += new Vector2(0, -0.03f * Mathf.Abs(playerInput.actions["Move"].ReadValue<Vector2>().y));
            }
            else if (playerInput.actions["Move"].ReadValue<Vector2>().y > 0 && viewButton.GetComponent<SwitchPerspective>().modeSide)
            {
                rb.velocity += new Vector2(0, 0.03f * Mathf.Abs(playerInput.actions["Move"].ReadValue<Vector2>().y));
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity += new Vector2(0, -(rb.velocity.y / 60.0f));
                }
                else if (rb.velocity.y < 0)
                {

                    if (Math.Abs(transform.localPosition.y - waterline) < .3f)
                    {
                        rb.velocity += new Vector2(0, -(rb.velocity.y / 10.0f));
                    }
                    else
                    {
                        rb.velocity += new Vector2(0, -(rb.velocity.y / 60.0f));
                    }
                }
            }
        }
        else
        {
            rb.gravityScale = 2f;
            rb.velocity += new Vector2(0.05f, 0);
        }

        //make it so that the sub falls when it is out of the waterline


        if (rb.velocity.y > maxspd)
        {
            rb.velocity = new Vector2(0,maxspd);
        }
        else if(rb.velocity.y < -maxspd)
        {
            rb.velocity = new Vector2(0, -maxspd);
        }

        //-4.5, 200

        if(transform.localPosition.y < waterline)
        {
            sr.color = new Color32((byte)(255 - (-(transform.localPosition.y - waterline) / .125f)), (byte)(255 - (-(transform.localPosition.y - waterline) / .125f)), (byte)(255 - (-(transform.localPosition.y - waterline) / .125f)), 255);

        }
        else
        {
            sr.color = Color.white;
        }

        
        for(int i = 0; i < depthLvls.Length; i++)
        {
            if (transform.localPosition.y < depthLvls[i])
            {
                SubT.SetInteger("Depth", i + 2);
            }
            else if(i == 0)
            {
                SubT.SetInteger("Depth", 1);
            }
        }

        SubT.gameObject.GetComponent<TopDownController>().depth = SubT.GetInteger("Depth");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SideObstacle"))
        {
            scoreManager.EndGame();

        }
    }
}
