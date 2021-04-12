using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Flip.Interact
{
    public class InteractingWithObjects : MonoBehaviour
    {
        public TMP_Text text;
        public string colliderLayer;//检测物品所在的图层
        // Start is called before the first frame update
        void Start()
        {
            text.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            Interact.GetInstance().Interacting(this.gameObject, 2, colliderLayer, TextSetTrue, TextSetFalse);
        }
        public void TextSetTrue()   //如果检测到就执行
        {
            text.gameObject.SetActive(true);
            text.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
        }
        public void TextSetFalse()  //没有检测到就执行
        {
            text.gameObject.SetActive(false);
        }

    }
}

