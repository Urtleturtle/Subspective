using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationPointDeath : MonoBehaviour
{
    public SideController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerS").GetComponent<SideController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        player.ExclamationMarkInstance = null;
        Destroy(gameObject);
    }
}
