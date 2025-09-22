using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    float holdTime;
    float maxHoldTime = 4f;
    float minHoldTime = 0f;
    public float maxForce = 300f;
    public float minForce = 100f;
    bool isHolding = false;

    GameManager gm;
    Rigidbody2D rb;

    [SerializeField] ParticleSystem bubbles;

    private void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!(gm.state == GameManager.GameState.launch)) { return; }
        Debug.Log(GetLaunchForce());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHolding = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHolding = false;
            gm.currentBall.AddForce(GetLaunchForce());
            holdTime = 0f;
            gm.ToPlayState();

            bubbles.Play();
        }

        if (isHolding) { holdTime += Time.deltaTime; }
    }

    private float GetLaunchForce()
    {
        float f = (maxForce - minForce) / (maxHoldTime - minHoldTime) * holdTime + minForce;
        return f > maxForce ? maxForce : f;
    }
}
