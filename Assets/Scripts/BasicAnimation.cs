using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasicAnimation : MonoBehaviour
{
    public float pause;
    public Sprite[] sprites;
    public int curr = 0;
    public Image i;
    // Start is called before the first frame update
    void Start()
    {
        i = GetComponent<Image>();
        StartCoroutine(nextSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator nextSprite()
    {
        yield return new WaitForSeconds(pause);
        if (curr >= sprites.Length - 1)
        {
            curr = 0;
        }
        else
        {
            curr++;
        }
        i.sprite = sprites[curr];
        StartCoroutine(nextSprite());
    }
}
