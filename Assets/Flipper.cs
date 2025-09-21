using UnityEngine;
public class Flipper : MonoBehaviour
{
    public bool invertRotation = false;
    public float upForce = 100f;
    public float downForce = 40f;

    Rigidbody2D rb;
    HingeJoint2D joint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<HingeJoint2D>();

        Vector2 anchorPos = new Vector2
        (
            -transform.localPosition.x / transform.localScale.x,
            -transform.localPosition.y / transform.localScale.y
        );

        Debug.Log(anchorPos);
        joint.anchor = anchorPos;
    }

    private void Update()
    {
        int r = invertRotation ? -1 : 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * upForce * r, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.up * -downForce * r, ForceMode2D.Force);
        }
    }
}
