using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numRows = 5;
    public int numCols = 5;
    public float horizontalSpeed = 3f;
    public float verticalSpeed = 1f;
    public float edge = 0.5f;

    private Vector2 moveDirection = Vector2.right;
    
    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        transform.position += new Vector3(moveDirection.x * horizontalSpeed * Time.deltaTime, 0f, 0f);

        if (isEdgeReached())
        {
            moveDirection = -moveDirection;
            transform.position += new Vector3(0f, -verticalSpeed, 0f);
        }
    }

    void SpawnEnemies()
    {
        Vector2 startPos = new Vector2(0f, 4f);
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Vector2 spawnPos = new Vector2(col * (enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 0.5f),
                    row * (enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.y + 0.5f));
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
            }
        }
    }

    bool isEdgeReached()
    {
        float leftEdge = transform.position.x - (numCols * (enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 0.5f) / 2);
        float rightEdge = transform.position.x + (numCols * (enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x + 0.5f) / 2);
        if (leftEdge <= -8 + edge || rightEdge >= 8 - edge)
        {
            return true;
        }

        return false;
    }
}
