using System.Collections;
using UnityEngine;

public class bullet : MonoBehaviour
{
   public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 500f;
    public float maxLifetime = 10f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
 public void Project(Vector2 direction)
    {
       
        rigidbody.AddForce(direction * speed);

        Destroy(gameObject, maxLifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Destroy(gameObject);
    }

}
