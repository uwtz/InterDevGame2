using UnityEngine;

public class Spring : MonoBehaviour
{
    public bool invertDirection = false;
    public float force = 500f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int d = invertDirection ? -1 : 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force * d, ForceMode2D.Impulse);
        }
    }
}
