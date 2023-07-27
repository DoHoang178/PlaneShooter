using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 2f;

    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", deactivate_Timer);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            Debug.Log("enemy va cham deathzone");
            Destroy(gameObject);

        }
    }
}
