//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Flip.PlayerControll;

//public class GetAttack : MonoBehaviour
//{
//    #region 字段

//    private Renderer render;
//    private EntityInput entityInput;

//    #endregion

//    #region Unity回调

//    private void Awake()
//    {
//        entityInput = GetComponent<EntityInput>();
//        render = GetComponent<Renderer>();
//    }

//    #endregion

//    #region 方法

//    public void GetInvincible()
//    {
//        entityInput.InvincibleTimer += Time.deltaTime;

//        if (entityInput.InvincibleTimer < 3f)
//        {
//            entityInput.IsInvincible = true;
//        }
//    }

//    //受伤之后闪烁
//    public void Flash()
//    {
//        if (entityInput.IsInvincible)
//        {
//            entityInput.TimeSpentInvincible += Time.deltaTime;

//            if (entityInput.TimeSpentInvincible < 3f)
//            {
//                float _remainder = entityInput.TimeSpentInvincible % 0.3f;
//                render.enabled = _remainder > 0.15f;
//            }

//            else
//            {
//                render.enabled = true;
//                entityInput.IsInvincible = false;
//            }
//        }
//    }
//    #endregion
//}
