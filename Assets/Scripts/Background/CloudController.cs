using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Background
{
    public class CloudController : MonoBehaviour
    {
        [SerializeField] private Sprite[] cloudSprites;
        [SerializeField] private float minOpacity, maxOpacity;
        [SerializeField] private float minSize, maxSize;
        [SerializeField] private float minFallSpeed, maxFallSpeed;

        private SpriteRenderer _spriteRenderer;
        private Vector2 _cameraSize;
        private float _fallSpeed;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _cameraSize = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        }

        private void Start()
        {
            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            _spriteRenderer.sprite = null;
            yield return new WaitForSeconds(Random.Range(0f, 5f));

            RandomizeCloud();
        }

        private void Update()
        {
            transform.position -= Vector3.up * _fallSpeed * Time.deltaTime;

            if (transform.position.y < -_cameraSize.y - 5)
            {
                RandomizeCloud();
            }
        }

        private void RandomizeCloud()
        {
            transform.position = new Vector2(Random.Range(-_cameraSize.x, _cameraSize.x), _cameraSize.y + 5);
            _spriteRenderer.sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
            _spriteRenderer.color = new Color(1, 1, 1, Random.Range(minOpacity, maxOpacity));
            transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
            _fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
            transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.forward);
        }
    }
}