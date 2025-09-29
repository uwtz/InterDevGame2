using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] int point = 1000;
    Animator animator;
    AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddPoint(point);

        animator.SetTrigger("spin");
        audioSource.Play();
    }
}
