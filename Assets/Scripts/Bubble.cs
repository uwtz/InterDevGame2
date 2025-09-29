using UnityEngine;

public class Bubble : MonoBehaviour
{
    Collider2D coll;
    SpriteRenderer sr;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void ResetBubble()
    {
        coll.enabled = true;
        sr.enabled = true;
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            coll.enabled = false;
            sr.enabled = false;
        }
    }
}
