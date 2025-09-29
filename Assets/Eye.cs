using UnityEngine;

public class Eye : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.currentBall != null)
        {
            Vector2 dir = GameManager.Instance.currentBall.transform.position - transform.position;
            dir = dir.normalized;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x));
        }
    }
}
