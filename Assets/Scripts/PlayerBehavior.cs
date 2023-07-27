using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -3f; // Minimum X position
    public float maxX = 3f;  // Maximum X position
    public float minY = -3f; // Minimum Y position
    public float maxY = 3f;  // Maximum Y position

    [SerializeField]
    public GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;
    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;

    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTimer = attackTimer;
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }
    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;
        Vector2 newPosition = (Vector2)transform.position + movement;

        // Clamp the new position within the defined limits
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
    public void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            canAttack = false;
            attackTimer = 0f;
            Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            gc.SetGameoverState(true);
            Debug.Log("player da va cham enemy");
        }
        if (col.CompareTag("EnemyBullet"))
        {
            gc.SetGameoverState(true);
            Destroy(col.gameObject);
            Debug.Log("player da va cham enemy");
        }
    }
}
