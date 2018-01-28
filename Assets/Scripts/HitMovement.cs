using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMovement : MonoBehaviour {

    public GameObject Coin;


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Coin = Instantiate(Coin, new Vector2(transform.position.x, transform.position.y + 0.2f), Quaternion.identity);
            Destroy(gameObject);
            Destroy(Coin, 3f);
        }
    }
}
