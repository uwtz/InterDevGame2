using UnityEngine;

public class LaunchStateTriggerHelper : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (GameManager.Instance.state != GameManager.GameState.launch)
            {
                GameManager.Instance.ToLaunchState();
            }
        }
    }
}
