using UnityEngine;

public class Bubbles : MonoBehaviour
{
    float cooldown = 4f;
    float lastTimeBubbled = 0f;
    float activeTime = 1f;

    [SerializeField] ParticleSystem ps;

    private void Update()
    {
        if (Time.time - lastTimeBubbled >= cooldown)
        {
            lastTimeBubbled = Time.time;
            cooldown = Random.Range(4f, 8f);
            ps.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball" &&
            Time.time - lastTimeBubbled < activeTime)
        {
            col.gameObject.GetComponent<Ball>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
        }
    }
}
