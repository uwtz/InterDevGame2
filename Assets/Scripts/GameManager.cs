using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { launch, play };
    public GameState state = GameState.launch;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform ballSpawnPoint;

    public Ball currentBall;

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

    private void Update()
    {
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
        currentBall = Instantiate(ballPrefab, ballSpawnPoint).GetComponent<Ball>();
    }

    public void ToPlayState()
    {
        state = GameState.play;
    }
}
