using System.Collections;
using UnityEngine;

namespace Audio
{
    public class AudioSyncScale : AudioSyncer
    {
        [SerializeField] private Vector3 beatScale;
        [SerializeField] private Vector3 restScale;
        [SerializeField] private float beatSmoothTime;
        [SerializeField] private float restSmoothTime;

        private Coroutine _moveToScale;

        protected override void Update()
        {
            base.Update();

            if (_moveToScale != null) return;

            transform.localScale = Vector3.Lerp(transform.localScale, restScale, Time.deltaTime / restSmoothTime);
        }

        protected override void OnBeat()
        {
            base.OnBeat();

            if (_moveToScale != null)
            {
                StopCoroutine(_moveToScale);
            }

            _moveToScale = StartCoroutine(MoveToScale());
        }

        private IEnumerator MoveToScale()
        {
            Vector3 current = transform.localScale;
            Vector3 initial = current;
            float timer = 0;

            while (current != beatScale)
            {
                current = Vector3.Lerp(initial, beatScale, timer / beatSmoothTime);
                timer += Time.deltaTime;

                transform.localScale = current;
                yield return null;
            }

            _moveToScale = null;
        }
    }
}