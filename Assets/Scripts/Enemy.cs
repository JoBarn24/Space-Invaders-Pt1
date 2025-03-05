using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Enemy died: 10 points");
            OnEnemyDied?.Invoke(10);
        }
        
        Destroy(gameObject);
    }
}
