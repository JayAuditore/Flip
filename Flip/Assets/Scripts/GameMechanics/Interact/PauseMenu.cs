using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Flip.PauseMenu
{
    public enum GameState
    {
        Running,
        Pause
    }
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu _instance;
        public GameState gameState = GameState.Running;
        public GameObject PauseCanvas;
        private void Awake()
        {
            _instance = this;
            if (PauseCanvas.activeSelf)
            {
                gameState = GameState.Pause;
            }
            else
            {
                gameState = GameState.Running;
            }
        }
        //测试添加删除物品
        private void Update()
        {
            KeyCodeToPause();
        }
        //改变游戏的运行状态，运行与暂停
        public void TransformGameState()
        {
            if (gameState == GameState.Running)
            {
                PauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameState = GameState.Pause;
            }
            else if (gameState == GameState.Pause)
            {
                PauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                gameState = GameState.Running;
            }
        }
        //控制游戏的快捷键
        public void KeyCodeToPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _instance.TransformGameState();
            }
            if (gameState == GameState.Pause)
            {
                if (!Input.GetKey(KeyCode.Mouse0))
                {
                    Input.ResetInputAxes();
                }
                
            }
        }
    }
}
    