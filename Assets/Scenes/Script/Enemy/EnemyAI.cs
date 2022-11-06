using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Rigidbody2D rb;
    private bool isDodge;
    private float force=4f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = transform.position - target.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;

        if (isDodge)
        {
            rb.AddForce(transform.right*force, ForceMode2D.Impulse);
            isDodge = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==8)
            isDodge = true;
    }
}
