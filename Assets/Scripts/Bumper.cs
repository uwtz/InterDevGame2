using UnityEngine;

public class Bumper : MonoBehaviour
{
    int point = 100;
    Animator animator;
    AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.AddPoint(point);
        audioSource.Play();
        animator.SetTrigger("bump");
    }

    /*
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
    */
}
