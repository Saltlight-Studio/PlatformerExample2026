using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int damage = 1;
    public Factions targetFaction = Factions.Enemies;
    float timer = 2.0f;
    void Start()
    {
        Vector3 scaledRight = Vector2.right * transform.localScale.x;
        GetComponent<Rigidbody2D>().linearVelocity = scaledRight * 20.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (health.faction == targetFaction)
            {
                health.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
        
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

}
