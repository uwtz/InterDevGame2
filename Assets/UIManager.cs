using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI topScoreText;

    private void Update()
    {
        scoreText.text = "Score " + GameManager.Instance.score.ToString();
        topScoreText.text = "Top Score " + GameManager.Instance.topScore.ToString();
    }
}
