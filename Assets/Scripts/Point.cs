using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    float lifeTime = .5f;
    float bday;
    float spd = 5f;

    private void Start()
    {
        bday = Time.time;
    }
    private void Update()
    {
        if (Time.time - bday >= lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position += transform.up * spd * Time.deltaTime;
    }

    public void SetText(string s)
    {
        GetComponent<TextMeshProUGUI>().text = s;
    }
}
