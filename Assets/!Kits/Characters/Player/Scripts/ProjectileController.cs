using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 2f;

    private Vector2 direction;
    private bool destroyed = false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(Vector2 newDirection)
    {
        if (newDirection == Vector2.zero)
            { direction = Vector2.down; }
        else
            { direction = newDirection.normalized; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyed) return;

        if (collision.GetComponent<HurtCollider>() != null)
        {
            destroyed = true;
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            destroyed = true;
            Destroy(gameObject); 
        }
    }
}
