using UnityEngine;

public class Clam : MonoBehaviour
{
    int point = 250;
    Rigidbody2D rb;
    AudioSource audiosource;

    float coolDown = 1f;
    float timeLastOpened = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }

    /*
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.up * -5, ForceMode2D.Force);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - timeLastOpened >= coolDown)
        {
            GameManager.Instance.AddPoint(point);
            timeLastOpened = Time.time;
            rb.AddForce(transform.up * 100, ForceMode2D.Impulse);
            audiosource.Play();
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * -5f, ForceMode2D.Force);
    }
}
