using System.Collections;
using UnityEngine;
public class ShakingValue : MonoBehaviour
{
    public bool isDone => (shakeAsync == null);
    [Tooltip("震动的幅度"), SerializeField, Range(0, 0.2f)] private float shakeMutiply = 0.08f;             // 震动幅度
    [Tooltip("每震动一次需要的时间"), SerializeField, Range(0, 0.2f)] private float shakeRate = 0.06f;       // 震动频率
    [Tooltip("共震动几次"), SerializeField, Range(0, 15f)] private float shakeFrequency = 5;                // 震动次数
    [SerializeField] private Transform shakeTrans;      // 震动目标
    private Coroutine shakeAsync;                       // 震动协程
    public void Shake()
    {
        // 开始抖动
        // 防止多个协程进行
        if (shakeAsync == null)
        {
            // 开始抖动
            shakeAsync = StartCoroutine(ShakeIE(shakeTrans));
        }
    }
    private IEnumerator ShakeIE(Transform shakeTrans)
    {
        for (int i = 0; i < shakeFrequency; i++)
        {
            Vector2 ramdomVec2 = Random.insideUnitCircle;
            Vector3 originTrans = shakeTrans.transform.position;
            shakeTrans.transform.position += new Vector3(ramdomVec2.x, ramdomVec2.y, 0) * shakeMutiply;
            yield return new WaitForSeconds(shakeRate / 2);
            shakeTrans.transform.position = originTrans;
            yield return new WaitForSeconds(shakeRate / 2);
        }
        shakeAsync = null;
    }
}