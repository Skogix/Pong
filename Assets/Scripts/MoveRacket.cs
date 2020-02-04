using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
  // Racketspeed
  public float speed = 30f;
  // Hur unity ska läsa av inputs
  // (Edit -> Project Settings -> Input
  // automagi för vertikala inputs, wasd/arrows/controller/touch
  public string axis = "Vertical";
  void FixedUpdate()
  {
    // v = input i form av 1 till -1
    float v = Input.GetAxisRaw(axis);
    // sätt nuvarande komponents velocity till Vector2(x, y) * speed
    GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
  }
}
