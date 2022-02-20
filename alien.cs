using System.Collections;
using UnityEngine;

public class alien : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;

    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;
    public float movementSpeed = 50f;
    public float maxLifetime = 30f;

private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        transform.localScale = Vector3.one * size;
        rigidbody.mass = size;

        Destroy(gameObject, maxLifetime);
    }

 public void SetTrajectory(Vector2 direction)
    {
        rigidbody.AddForce(direction * movementSpeed);
    }
    
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
           

            Destroy(gameObject);
        }
    }

    private void CreateSplit()
    {
       
        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 0.5f;

        alien half = Instantiate(this, position, transform.rotation);
        half.size = size * 0.5f;

        half.SetTrajectory(Random.insideUnitCircle.normalized);

    }
  
}
