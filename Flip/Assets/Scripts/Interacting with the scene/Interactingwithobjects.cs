using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactingwithobjects : MonoBehaviour
{
    
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Interact.Interacting(this.gameObject, 2, "Square",textsettrue,textsetfalse);
        //raycasthit();
    }
    public void textsettrue()
    {
        text.gameObject.SetActive(true);
        text.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
    }
    public void textsetfalse()
    {
        text.gameObject.SetActive(false);
    }
    public void raycasthit()
    {
        float rads = 2;
        Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, rads, LayerMask.GetMask("Square"));
        if (cols.Length > 0)
        {
            text.gameObject.SetActive(true);
            text.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position +new Vector3(0,1.5f,0));
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
