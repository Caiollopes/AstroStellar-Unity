using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    
    public float initialSpeed = 7.0f;
    public float startPosY = 0.0f;

    private static float speed = 0.0f;
    private Rigidbody2D rb2d;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        ResetPosition();

        Invoke("GoAsteroid", 1);
    }

    void LevelUp() {
        ResetPosition();
        BumpSpeed();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")) {
            Stop();
            ResetPosition();
            GameManager.Crash();
            
            Invoke("GoAsteroid", 1);
        }
    }

    private void GoAsteroid() {
        speed = initialSpeed;
        rb2d.AddForce(new Vector2(RandomSpeedX(speed), -20));
    }

    private float RandomSpeedX(float baseSpeed) {
        float side = Random.Range(0, 2);
        float forceX = baseSpeed * Random.Range(10, 30);

        if (side < 1) {
            return -forceX;
        } else {
            return forceX;
        }
    }

    private void ResetPosition() {
        Vector2 pos;
        pos.x = 0;
        pos.y = 6.12f;
        rb2d.transform.position = pos;
    }

    private void Stop() {
        rb2d.velocity = Vector2.zero;
    }

    private void BumpSpeed() {
        float bumpY = speed * 1f;
        float bumpX = RandomSpeedX(bumpY);

        rb2d.AddForce(new Vector2(bumpX, -bumpY));
    }
}
