using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Flip.UI
{
    public class LoadSceneController : MonoBehaviour
    {
        #region 字段

        [SerializeField] private int Index;
        private Action<float> onPageChange;
        private Action onFinish;
        private static LoadSceneController instance;

        //单例
        public static LoadSceneController Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Unity回调

        private void Awake()
        {
            //不销毁
            DontDestroyOnLoad(gameObject);
            instance = this;
            ////如果不止一个controller，抛出异常
            //if (instance != null)
            //{
            //    throw new Exception("There's more than one scene controller. ");
            //}
        }

        #endregion

        #region 方法

        //加载场景
        public void LoadScene(int index, Action<float> onpagechange, Action onfinish)
        {
            this.Index = index;
            this.onPageChange = onpagechange;
            this.onFinish = onfinish;

            //开启协程
            StartCoroutine(LoadScenes());
        }

        //异步加载场景
        private IEnumerator LoadScenes()
        {
            yield return 0;
            //异步加载场景
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Index);

            while (!asyncOperation.isDone)
            {
                yield return 0;
                //传递异步加载进度，如果完成，progress=1
                onPageChange?.Invoke(asyncOperation.progress);
            }

            yield return new WaitForSeconds(2f);
            //在完成加载之后的操作
            onFinish?.Invoke();
        }

        #endregion

    }
}
