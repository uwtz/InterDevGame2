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


    float topspd = 0f;
    private void Update()
    {
        if (currentBall != null)
        {
            float spd = Mathf.Abs(currentBall.rb.linearVelocity.magnitude);
            if (spd >topspd)
            {
                topspd = spd;
                //Debug.Log(topspd);
            }

        }
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

        if (currentBall == null)
        {
            currentBall = Instantiate(ballPrefab, ballSpawnPoint).GetComponent<Ball>();
        }

    }

    public void ToPlayState()
    {
        state = GameState.play;
    }
}
