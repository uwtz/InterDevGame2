using UnityEngine;

public class PlayStateTriggerHelper : MonoBehaviour
{
    BoxCollider2D bc;
    SpriteRenderer sr;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            GameManager.Instance.ToPlayState();
            bc.isTrigger = false;
            sr.enabled = true;
        }
    }

    public void ResetHelper()
    {
        
        bc.isTrigger = true;
        sr.enabled = false;
    }
}
