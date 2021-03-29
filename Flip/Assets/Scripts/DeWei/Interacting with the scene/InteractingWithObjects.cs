using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractingWithObjects : MonoBehaviour
{
    public TMP_Text text;
    public Interact interact ;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        interact.Interacting(this.gameObject, 2, "Square", TextSetTrue, TextSetFalse);
    }
    public void TextSetTrue()
    {
        text.gameObject.SetActive(true);
        text.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
    }
    public void TextSetFalse()
    {
        text.gameObject.SetActive(false);
    }
    
}
