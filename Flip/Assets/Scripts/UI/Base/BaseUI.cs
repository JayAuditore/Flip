using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.UI.Base
{
    public class BaseUI : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
