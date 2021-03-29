using UnityEngine;
namespace Flip.UI
{
    public abstract class BaseUIController : BaseUI, IUserInterfacePreInit
    {
        public virtual bool isActive
        {
            get
            {
                return (gameObject == null ? false : gameObject.activeSelf);
            }
        }
        public abstract void PreInit();
    }
}