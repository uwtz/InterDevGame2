using NUnit.Framework;
using UnityEngine;
public class Flipper : MonoBehaviour
{
    private float force = 200f;
    public bool invertRotation = false;

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
        joint.anchor = anchorPos;
    }

    private void Update()
    {

        int r = invertRotation ? -1 : 1;
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(transform.up * force * r, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.up * force * -r, ForceMode2D.Force);
        }
        /*
        motor = joint.motor;
        int r = invertRotation ? -1 : 1;
        if (Input.GetKey(KeyCode.Space))
        {
            motor.motorSpeed = r * spd;
        }
        else
        {
            motor.motorSpeed = -r * spd;
        }
        joint.motor = motor;
        */
    }
}
