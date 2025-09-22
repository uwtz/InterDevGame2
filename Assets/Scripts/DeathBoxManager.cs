using UnityEngine;

public class DeathBoxManager : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(col.gameObject);
            gm.currentBall = null;
            gm.ToLaunchState();
        }
    }
}
