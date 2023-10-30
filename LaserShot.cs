using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour {
    public int damage;
    public float force;
    private Rigidbody2D rb;
 
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Vector3 directon = new Vector3(0, force, 0);
        rb.AddForce(directon, ForceMode2D.Impulse);
    }
 
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Asteroid") {
            GameManager.LevelUp();
            hitInfo.gameObject.SendMessage("LevelUp", 0.1f, SendMessageOptions.RequireReceiver);
        }
    }
}
