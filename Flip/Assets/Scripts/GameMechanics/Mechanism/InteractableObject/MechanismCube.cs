using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Flip.GameMechanics
{
    public class MechanismCube : BaseMechanismObject
    {
        [SerializeField] private ShakingValue shakingValue;
        [SerializeField] private ShakingValue cameraShakingValue;          // 相机抖动数值

        private Coroutine shakeCorouine;
        public override void Transformation()
        {
            // 先抖动 再下坠
            if (shakeCorouine == null)
            {
                shakeCorouine = StartCoroutine(TranfomationIE());
            }
        }
        public override void Reduction()
        {
            gameObject.transform.localPosition = startVec;
        }

        private IEnumerator TranfomationIE()
        {
            shakingValue?.Shake();
            while (!shakingValue.isDone)
            {
                yield return 0;
            }
            while ((gameObject.transform.localPosition - endVec).magnitude >= 0.01f)
            {
                gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, endVec, 0.3f);
                yield return null;
            }
            cameraShakingValue?.Shake();

            shakeCorouine = null;
        }
    }

}
