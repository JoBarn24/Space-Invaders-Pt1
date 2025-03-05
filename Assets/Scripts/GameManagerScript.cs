using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highscore = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        scoreText.text = score.ToString().PadLeft(4,'0');
        highScoreText.text = highscore.ToString().PadLeft(4,'0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
        Player.OnPlayerDied -= PlayerOnOnPlayerDied;
    }
    
    void EnemyOnOnEnemyDied(int points)
    {
        score += points;
        if (score > highscore)
        {
            highscore = score;
        }
        scoreText.text = score.ToString().PadLeft(4,'0');
        highScoreText.text = score.ToString().PadLeft(4,'0');
    }

    void PlayerOnOnPlayerDied()
    {
        
    }
}
