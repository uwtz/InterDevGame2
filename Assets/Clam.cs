using UnityEngine;

public class Clam : MonoBehaviour
{
    Rigidbody2D rb;

    float coolDown = 1f;
    float timeLastOpened = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            timeLastOpened = Time.time;
            rb.AddForce(transform.up * 100, ForceMode2D.Impulse);
        }
    }
}
