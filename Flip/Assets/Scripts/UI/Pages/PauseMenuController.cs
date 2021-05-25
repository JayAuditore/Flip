using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.UI
{
    public class PauseMenuController : MonoBehaviour
    {
        #region 字段

        private static PauseMenuController _instance;

        public Canvas Canvas;
        public GameState gameState;
        public static PauseMenuController Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject("PauseMenuController");
                    obj.AddComponent<PauseMenuController>();
                }
                return _instance;
            }
        }

        #endregion

        #region Unity回调

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            KeyCodeToPause();
        }

        #endregion

        #region 方法

        //控制游戏的快捷键
        public void KeyCodeToPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameState == GameState.Running)
                {
                    Canvas.gameObject.SetActive(true);
                    //Time.timeScale = 0;
                    gameState = GameState.Pause;
                }
                else if (gameState == GameState.Pause)
                {
                    Canvas.gameObject.SetActive(false);
                    //Time.timeScale = 1;
                    gameState = GameState.Running;
                }
            }
        }

        #endregion
    }
}
