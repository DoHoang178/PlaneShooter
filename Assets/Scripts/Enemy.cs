using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    GameController gc;
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            Debug.Log("enemy va cham deathzone");
            Destroy(gameObject);

        }
        if (col.CompareTag("PlayerBullet"))
        {
            health -= 1;
            Destroy(col.gameObject);
            if (health <= 0)
            {
                gc.ScoreIncrement();
                Destroy(gameObject);

            }
        }
    }
}
