using UnityEngine;

public class EnemyGroupController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 4;
    public int cols = 5;
    public float speed = 1f;

    private Vector3 direction = Vector3.right;

    void Start()
    {
        // Create enemies in a grid formation relative to the parent (this object)
        for (int row = 0; row < rows; row++)
        {
            float width = cols - 1;
            float height = rows - 1;
            Vector2 center = new Vector2(-width / 2, -height / 2 + 2f);
            Vector3 rowPos = new Vector3(center.x, center.y + row, 0f);

            for (int col = 0; col < cols; col++)
            {
                // Instantiate the enemy at the position of the parent
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                
                // Set the enemy's local position relative to the parent
                Vector3 position = rowPos;
                position.x += col;
                enemy.transform.localPosition = position; // Use local position here

                // Ensure the enemy is parented to this group
                enemy.transform.parent = transform;
            }
        }
    }

    void Update()
    {
        // Move the entire group in the current direction (this will move the parent object)
        transform.position += direction * speed * Time.deltaTime;

        // Calculate the leftmost and rightmost positions of the entire enemy group (parent object)
        float groupLeft = transform.position.x - (cols * 0.5f); // Left edge of the group
        float groupRight = transform.position.x + (cols * 0.5f); // Right edge of the group

        // Get the camera's left and right edges in world space
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // If the group reaches the right edge of the screen, reverse the direction and move down
        if (direction == Vector3.right && groupRight >= rightEdge.x - 0.25f)
        {
            AdvanceRow();
        }
        // If the group reaches the left edge of the screen, reverse the direction and move down
        else if (direction == Vector3.left && groupLeft <= leftEdge.x + 0.25f)
        {
            AdvanceRow();
        }
    }

    void AdvanceRow()
    {
        // Reverse the direction of the entire group
        direction.x *= -1f;

        // Move the group down by one unit
        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }
}
