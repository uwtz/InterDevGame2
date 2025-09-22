using UnityEngine;

public class Cam : MonoBehaviour
{
    Transform ballTransform;
    [SerializeField] float smoothVal;
    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (ballTransform == null && GameManager.Instance.currentBall != null)
        {
            ballTransform = GameManager.Instance.currentBall.transform;
        }

        if (ballTransform != null)
        {
            Vector3 target = ballTransform.position;
            target.z = -10;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        }
    }
}
