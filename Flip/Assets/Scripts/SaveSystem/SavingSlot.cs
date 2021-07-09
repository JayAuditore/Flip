using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flip.SaveSystem
{
    public class SavingSlot
    {
        #region 字段

        [SerializeField] private int _slotIndex;                    // 存档序号
        [SerializeField] private Text _time;                        // 保存时间
        [SerializeField] private Image _backGround;                 // 存档背景

        #endregion

        #region 方法

        /// <summary>
        /// 给存档上编号
        /// </summary>
        /// <param name="slotIndex">编号</param>
        public void InitSavingSlot(int slotIndex)
        {
            _slotIndex = slotIndex;
        }

        /// <summary>
        /// 设置存档信息
        /// </summary>
        /// <param name="_timeStr">时间</param>
        public void SetSlotFilled(string _timeStr)
        {
            _time.text = _timeStr;
            _backGround.color=SavingController.Instance.FillColor;
        }

        /// <summary>
        /// 存档为空的时候的设置
        /// </summary>
        public void SetSlotEmpty()
        {
            _time.text="空";
            _backGround.color=SavingController.Instance.DefaultColor;
        }

        #endregion
    }
}
