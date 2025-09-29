using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] float force = 75f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            Vector2 ballDir = ball.rb.linearVelocity;
            if (Vector2.Dot(transform.up, ballDir) > 0) // if ball is in the same dir, boost
            {
                ball.AddForce(transform.up * force, ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
