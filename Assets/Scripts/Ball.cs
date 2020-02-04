using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  // speed på ball
  public float speed = 30f;

  void Start()
  {
    // sätt ball velocity åt höger * speed
    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
  }

  // dela skillnaden mellan ball och racket med höjden av racket
  // (1 = toppen, -1 = botten)
  // aka ändra vinkel beroende på var på racket bollen träffar
  float hitFactor(Vector2 ballPos, 
                  Vector2 racketPos, 
                  float racketHeight)
  {
    return ballPos.y - racketPos.y / racketHeight;
  }

  private void OnCollisionEnter2D(Collision2D col)
  {
    // col håller collisioninfon, om collide med racket:
    // col.gameObject = racket
    // col.transform.position = rackets position
    // col.collider är rackets collider (aka ball)

    // är det vänstra?
    if (col.gameObject.name == "RacketLeft")
    {
      // räkna ut hitfactor
      float y = hitFactor(transform.position, 
                          col.transform.position, 
                          col.collider.bounds.size.y);
      // räkna ut dir, normalized gör length=1
      Vector2 dir = new Vector2(1, y).normalized;
      // sätt velocity = dir * speed
      GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
    // är det högra?
    if (col.gameObject.name == "RacketRight")
    {
      // räkna ut hitfactor
      float y = hitFactor(transform.position,
                          col.transform.position,
                          col.collider.bounds.size.y);
      // räkna ut dir, normalized gör length=1
      Vector2 dir = new Vector2(-1, y).normalized;
      // sätt velocity = dir * speed
      GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
  }
}
