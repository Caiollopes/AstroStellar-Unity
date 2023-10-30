using UnityEngine;
using System.Collections;

public class BottomWall : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Asteroid") {
            GameManager.LevelUp();
            hitInfo.gameObject.SendMessage("LevelUp", 0.1f, SendMessageOptions.RequireReceiver);
        }
    }
}