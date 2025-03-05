using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;
  public Transform shootingOffset;
  public delegate void PlayerDied();
  public static event PlayerDied OnPlayerDied;

  Animator playerAnimator;
  
  void Start()
  {
    playerAnimator = GetComponent<Animator>();
  }
  
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    { 
      playerAnimator.SetTrigger("Shoot Trigger");
      GameObject shot = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity); 
      Physics2D.IgnoreCollision(GetComponent<Collider2D>(), shot.GetComponent<Collider2D>());
      
      //Destroy(shot, 3f);
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(collision.gameObject);
      
    OnPlayerDied?.Invoke();
      
    //todo kill player
  }
}
