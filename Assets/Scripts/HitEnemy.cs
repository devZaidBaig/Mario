using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour {

    public GameObject Enemy;
    public bool isDead = false;

    private Animator animator;

    private void Start()
    {
        animator = Enemy.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            isDead = true;
            animator.SetBool("Dead", true);
            Destroy(Enemy, 0.5f);
        }
    }
}
