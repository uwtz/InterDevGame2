using NUnit.Framework;
using UnityEngine;
public class Flipper : MonoBehaviour
{
    private float force = 325f;
    public bool invertRotation = false;

    Rigidbody2D rb;
    HingeJoint2D joint;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<HingeJoint2D>();
        audioSource = GetComponent<AudioSource>();

        Vector2 anchorPos = new Vector2
        (
            -transform.localPosition.x / transform.localScale.x,
            -transform.localPosition.y / transform.localScale.y
        );
        //joint.anchor = anchorPos;
    }

    private void FixedUpdate()
    {
        int r = invertRotation ? -1 : 1;
        if (GameManager.Instance.state == GameManager.GameState.play)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                rb.AddForce(transform.up * force * r, ForceMode2D.Impulse);
                if (hit) { audioSource.Play(); }
            }
            else
            {
                rb.AddForce(transform.up * force * -r, ForceMode2D.Force);
            }
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

    bool hit = false;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            hit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            hit = false;
        }
    }
}
