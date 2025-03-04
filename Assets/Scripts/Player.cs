using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;
  public Transform shottingOffset;

  Animator playerAnimator;
  void Start()
  {
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    playerAnimator = GetComponent<Animator>();
  }

  void OnDestroy()
  {
    Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
  }

  void EnemyOnOnEnemyDied(int points)
  {
    Debug.Log($"I know about dead enemy, points: {points}");
  }
  
  
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    { 
      playerAnimator.SetTrigger("Shoot Trigger");
      GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity); 
      Debug.Log("Bang!");

      //Destroy(shot, 3f);
    }
  }
}
