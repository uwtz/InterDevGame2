using NUnit.Framework;
using UnityEngine;
public class Flipper : MonoBehaviour
{
    private float force = 2000f;
    public bool invertRotation = false;

    Rigidbody2D rb;
    HingeJoint2D joint;
    JointMotor2D motor;

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
        motor = joint.motor;
        int r = invertRotation ? -1 : 1;
        if (Input.GetKey(KeyCode.Space))
        {
            motor.motorSpeed = r * force;
        }
        else
        {
            motor.motorSpeed = -r * force;
        }
        joint.motor = motor;
    }
}
