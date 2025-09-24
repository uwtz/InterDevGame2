using UnityEngine;

public class Cam : MonoBehaviour
{
    Transform ballTransform;
    [SerializeField] float smoothVal;
    Vector3 velocity = Vector3.zero;

    Vector3 initialOffset;

    float yMax = 21f;
    float yMin = -30f;

    private void Start()
    {
        initialOffset = transform.position;
    }

    private void Update()
    {
        if (ballTransform == null && GameManager.Instance.currentBall != null)
        {
            ballTransform = GameManager.Instance.currentBall.transform;
        }

        if (ballTransform != null)
        {
            Vector3 target = new Vector3(0, ballTransform.position.y, 0) + initialOffset;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);

            newPos.y = newPos.y > yMax ? yMax : newPos.y;
            newPos.y = newPos.y < yMin ? yMin : newPos.y;

            transform.position = newPos;
        }
    }
}
