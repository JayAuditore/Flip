using Flip.UI.Base;
using Flip.SaveSystem.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;

namespace Flip.SaveSystem
{
    public class SavingController : BaseUI, IUserInterfaceInit
    {
        #region 字段
        [SerializeField] private Transform _container;           // 插槽生成容器
        [SerializeField] private GameObject _saveSlotPrefab;     // 插槽预制体

        private SavingSlot[] _savingSlots;
        private static SavingController _instance;

        [Tooltip("UI无存档颜色")] public Color DefaultColor;
        [Tooltip("UI有存档颜色")] public Color FillColor;

        public static SavingController Instance
        {
            get { return _instance; }
        }


        #endregion

        #region Unity回调

        private void OnEnable()
        {
            ChangeSaveSlotState();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 对存档初始化，把格子加载出来，并加上SavingSlot脚本
        /// </summary>
        public void Init()
        {
            _savingSlots = new SavingSlot[SaveManager.Instance.MaxSaveSlot];
            for (int i = 0; i < SaveManager.Instance.MaxSaveSlot; i++)
            {
                _savingSlots[i] = UIResourcesManager.Instance.LoadUserInterface(_saveSlotPrefab, _container).GetComponent<SavingSlot>();
                _savingSlots[i].InitSavingSlot(i);
            }
        }

        /// <summary>
        /// 每次打开存档页面的时候，修改存档的状态
        /// </summary>
        public void ChangeSaveSlotState()
        {
            var _saveDics = SaveManager.Instance.LoadSaveDics();

            for (int i = 0; i < _saveDics.Length; i++)
            {
                // 该存档有数据
                if (_saveDics[i] != null && _saveDics[i].ContainsKey("saveTime"))
                {
                    _savingSlots[i].SetSlotFilled(_saveDics[i]["saveTime"] as string);
                }
                // 该存档无数据
                else
                {
                    _savingSlots[i].SetSlotEmpty();
                }
            }
        }

        #endregion
    }
}