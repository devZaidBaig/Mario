using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private GameObject Player;
    private Rigidbody2D body;
    private bool directionRight = false;

    public float speed = 0.5f;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        body.velocity = new Vector2(speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && !GetComponentInChildren<HitEnemy>().isDead)
        {
            Debug.Log("Player PowerUp");
        }
        speed *= -1;
    }



    void Flip()
    {
        directionRight = !directionRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
