//using UnityEngine;
//using UnityEngine.UI;
//using Flip.UI;

//namespace Flip.SaveSystem
//{
//    public class SavingOption : BaseUI
//    {
//        #region 字段

//        [SerializeField] private Button saveButton;
//        [SerializeField] private Button loadButton;
//        [SerializeField] private Button deleteButton;

//        #endregion

//        #region 方法

//        public void SetCanLoad(bool _isFilled)
//        {
//            // 只有当存在存档时 它才可被加载或删除
//            loadButton.gameObject.SetActive(_isFilled);
//            deleteButton.gameObject.SetActive(_isFilled);
//        }

//        #endregion
//    }
//}