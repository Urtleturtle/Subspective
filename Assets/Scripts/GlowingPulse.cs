using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlowingPulse : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TMP_FontAsset TitleFont;
    public Material TitleMaterial;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        Title = GetComponent<TextMeshProUGUI>();
        TitleMaterial = new Material(Title.fontSharedMaterial);
        StartCoroutine(Glow(0.28f, true));
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Glow(float start, bool rising)
    {

        yield return new WaitForSeconds(delay);
        TitleMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, start);
        Title.fontSharedMaterial = TitleMaterial;
        Title.UpdateMeshPadding();

        if(start < 0.9f && rising)
        {
            StartCoroutine(Glow(start + 0.01f, true));
        }
        else if(start < 0.30f && !rising)
        {
            StartCoroutine(Glow(start + 0.01f, true));
        }
        else
        {
            StartCoroutine(Glow(start - 0.01f, false));
        }
        
    }
}
