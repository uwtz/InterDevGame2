using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { launch, play };
    public GameState state = GameState.launch;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballSpawnPoint;

    public Ball currentBall;

    [SerializeField] PlayStateTriggerHelper playStateTriggerHelper;
    [SerializeField] Bubble bubble;

    [SerializeField] GameObject pointPopup;
    [SerializeField] Canvas canvas;

    public float topScore;
    public float score;

    public void AddPoint(int p)
    {
        score += p;
        GameObject pText = Instantiate(pointPopup, currentBall.transform.position, Quaternion.identity, canvas.transform);
        pText.GetComponent<Point>().SetText(p.ToString());
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ToLaunchState();
    }


    //float topspd = 0f;
    private void Update()
    {
        /*
        if (currentBall != null)
        {
            float spd = Mathf.Abs(currentBall.rb.linearVelocity.magnitude);
            if (spd >topspd)
            {
                topspd = spd;
                //Debug.Log(topspd);
            }
        }
        */

        switch (state)
        {
            case GameState.launch:
                break;
            case GameState.play:
                break;
        }
    }

    public void ToLaunchState()
    {
        state = GameState.launch;
        playStateTriggerHelper.ResetHelper();
        bubble.ResetBubble();

        if (currentBall == null)
        {
            currentBall = Instantiate(ballPrefab, ballSpawnPoint.transform.position, Quaternion.identity).GetComponent<Ball>();
        }

    }

    public void ToPlayState()
    {
        state = GameState.play;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (score > topScore)
        { topScore = score; }
        score = 0;
    }
}


