using UnityEngine;

public class Ball : MonoBehaviour
{
    enum BallState { normal, expand };
    BallState state = BallState.normal;

    /*
    float scaleNormal = .3f;
    float scaleExpand = .6f;
    float gravityNormal = 10f;
    float gravityExpand = 3f;*/
    float scaleNormal = 1f;
    float scaleExpand = 2f;
    float gravityNormal = 4f;
    float gravityExpand = 1.5f;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector3 f, ForceMode2D fm)
    {
        rb.AddForce(f, fm);
    }

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.GameState.play)
        {
            if (Input.GetKey(KeyCode.X))
            {
                state = BallState.expand;
            }
            else
            {
                state = BallState.normal;
            }
        }
        else { state = BallState.normal; }

        switch (state)
        {
            case BallState.normal:
                transform.localScale = new Vector3(scaleNormal, scaleNormal, scaleNormal);
                rb.gravityScale = gravityNormal;
                break;
            case BallState.expand:
                transform.localScale = new Vector3(scaleExpand, scaleExpand, scaleExpand);
                rb.gravityScale = gravityExpand;
                break;
        }
    }
}
