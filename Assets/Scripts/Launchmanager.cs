using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    float holdTime;
    float maxHoldTime = 2f;
    float minHoldTime = 0f;
    public float maxForce = 300f;
    public float minForce = 100f;
    bool isHolding = false;

    GameManager gm;

    [SerializeField] ParticleSystem bubbles;

    [SerializeField] Transform MeterJoint;
    float minMeterRotation = 0f;
    float maxMeterRotation = 250f;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void Update()
    {
        if (!(gm.state == GameManager.GameState.launch)) { return; }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isHolding = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            isHolding = false;
            gm.currentBall.AddForce(transform.up * GetLaunchForce(), ForceMode2D.Impulse);
            holdTime = 0f;
            gm.ToPlayState();

            bubbles.Play();
            GetComponent<AudioSource>().Play();
        }

        if (isHolding) { holdTime += Time.deltaTime; }

        MeterJoint.transform.rotation = Quaternion.Euler(0, 0, -GetMeterRotation());
    }

    private float GetLaunchForce()
    {
        float f = (maxForce - minForce) / (maxHoldTime - minHoldTime) * holdTime + minForce;
        return f > maxForce ? maxForce : f;
    }

    private float GetMeterRotation()
    {
        float r = (maxMeterRotation - minMeterRotation) / (maxHoldTime - minHoldTime) * holdTime;
        return r > maxMeterRotation ? maxMeterRotation : r;
    }
}
