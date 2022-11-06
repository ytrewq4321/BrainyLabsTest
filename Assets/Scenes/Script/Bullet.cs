using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private bool isRicochet;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(6, 9);
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Ricochet(collision);    
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GlobalEventManager.PlayerDied.Invoke();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            GlobalEventManager.EnemyDied.Invoke();
        }
        else if(collision.gameObject.CompareTag("Border"))
            Destroy(gameObject);
    }

    private void Ricochet(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var wallNormal = collision.GetContact(0).normal;
        var newDirection = Vector2.Reflect(lastVelocity.normalized, wallNormal);
        rb.velocity = newDirection * speed;
        if (gameObject.layer==8 && !isRicochet)
        {
            isRicochet = true;
            GlobalEventManager.Ricochet.Invoke();
        }  
    }
}
