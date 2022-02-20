using System.Collections;
using UnityEngine;

namespace Audio
{
    public class AudioSyncScale : AudioSyncer
    {
        public Vector3 beatScale;
        public Vector3 restScale;

        private Coroutine _moveToScale;

        protected override void Update()
        {
            base.Update();

            if (IsBeat) return;

            transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
        }

        public override void OnBeat()
        {
            base.OnBeat();

            if (_moveToScale != null)
            {
                StopCoroutine(_moveToScale);
            }

            _moveToScale = StartCoroutine(MoveToScale(beatScale));
        }

        private IEnumerator MoveToScale(Vector3 target)
        {
            Vector3 current = transform.localScale;
            Vector3 initial = current;
            float timer = 0;

            while (current != target)
            {
                current = Vector3.Lerp(initial, target, timer / timeToBeat);
                timer += Time.deltaTime;

                transform.localScale = current;
                yield return null;
            }

            IsBeat = false;
        }
    }
}