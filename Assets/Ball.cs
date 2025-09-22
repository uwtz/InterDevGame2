using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddForce(float f)
    {
        rb.AddForce(f * transform.up, ForceMode2D.Impulse);
    }
}
