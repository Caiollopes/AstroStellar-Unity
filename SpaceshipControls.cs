using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControls : MonoBehaviour {

      public float speed = 0;

  Vector3 move;
  Vector3 clickPos;
  Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    clickPos = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButton(0)) {
      clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    move = clickPos - transform.position;
  }

  void FixedUpdate() {
    rb.velocity = new Vector2(move.x, move.y);
  }
}
