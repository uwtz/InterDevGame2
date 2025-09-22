using UnityEngine;

public class Bumper : MonoBehaviour
{
    float force = 60f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Vector3 dir = col.gameObject.transform.position - transform.position;
            Vector3 f = dir.normalized * force;
            col.gameObject.GetComponent<Ball>().AddForce(f, ForceMode2D.Impulse);
        }
    }
}
