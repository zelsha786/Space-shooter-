
using UnityEngine;

public class player : MonoBehaviour
{
    public bullet bulletPrefabs;
    public float thurstSpeed = 1.0f;
    public float turnSpeed = 1.0f;
 
    private  Rigidbody2D _rigibody;
    private bool _thursting;
    private float _turnDirection;
    void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    
    }

    private void Update()
    {
        _thursting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0F;
        }  else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turnDirection = -1.0f;}
            else
            {
                _turnDirection = 0.0f;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }
        private void FixedUpdate() {
            if(_thursting){
                _rigibody.AddForce(this.transform.up * this.thurstSpeed);
            }
            if (_turnDirection != 0.0f){
            _rigibody.AddTorque(_turnDirection * thurstSpeed);
            }
        }
          private void Shoot()
    {
        bullet bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        bullet.Project(transform.up);
    }
    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag== "alien")
        {
            _rigibody.velocity = Vector3.zero;
            _rigibody.angularVelocity = 0.0f;
            gameObject.SetActive(false);
        }
}
}


    