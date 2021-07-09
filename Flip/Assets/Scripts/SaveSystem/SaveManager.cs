using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
using System.IO;

namespace Flip.SaveSystem
{
    public class SaveManager : BaseSingletonWithMono<SaveManager>
    {
        #region 字段

        public int MaxSaveSlot = 4;

        [SerializeField] private string _saveName = "MySave";
        [SerializeField] private string _saveSuffix = ".save";

        #endregion

        #region 方法

        /// <summary>
        /// 读取保存的存档
        /// </summary>
        /// <returns>反序列化之后的存档</returns>
        public Dictionary<string, object>[] LoadSaveDics()
        {
            // 获得保存路径
            string savePath = GetSavePath();

            // 若不存在存档文件 则新创建字典数组
            if (!File.Exists(savePath))
            {
                return new Dictionary<string, object>[MaxSaveSlot];
            }

            // 存在存档文件 进行读取并反序列化
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);
            Dictionary<string, object>[] _saveDics = formatter.Deserialize(fileStream) as Dictionary<string, object>[];
            fileStream.Close();

            return _saveDics;
        }

        /// <summary>
        /// 获取保存路径
        /// </summary>
        /// <returns>保存路径</returns>
        private string GetSavePath()
        {
            return string.Concat(Path.Combine(Application.persistentDataPath, _saveName), _saveSuffix);
        }

        #endregion
    }
}
