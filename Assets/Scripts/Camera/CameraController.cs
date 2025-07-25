using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Vector3 _camMenuPosition;
    [SerializeField] private Vector3 _camPlayPosition;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float shakeDuration = 0.3f;
    [SerializeField] private float shakeMagnitude = 0.2f;
    [SerializeField] private AnimationCurve movementCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public Vector3 _originalCamPos;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        

        _originalCamPos = _mainCamera.transform.localPosition;
        transform.position = _camMenuPosition; // Set initial position
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    public void MoveCamera(bool isGameStarted)
    {
        StartCoroutine(MoveCameraCoroutine(isGameStarted));
    }

    // For Shaking
    private IEnumerator ShakeCameraCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomPoint = _originalCamPos + Random.insideUnitSphere * shakeMagnitude;
            _mainCamera.transform.localPosition = new Vector3(randomPoint.x, randomPoint.y, _originalCamPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        _mainCamera.transform.localPosition = _originalCamPos;
    }

    // For Moving
    private IEnumerator MoveCameraCoroutine(bool isGameStarted)
    {
        if (isGameStarted) {
            LevelManager.Instance.RespawnCubes();
        }
        
        Vector3 targetPosition = isGameStarted ? _camPlayPosition : _camMenuPosition;
        Vector3 startPos = transform.position;
        float elapsed = 0f;
        float moveDuration = 1f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            float curveT = movementCurve.Evaluate(t);
            transform.position = Vector3.Lerp(startPos, targetPosition, curveT);
            yield return null;
        }

        transform.position = targetPosition;

        if (isGameStarted)
        {
            LevelManager.Instance.ResetLevel();
        }
    }
}
