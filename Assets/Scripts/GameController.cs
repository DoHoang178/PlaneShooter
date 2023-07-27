using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyBullet;
    public float spawnTime;
    public float spawnBulletTime;
    float mSpawnTime;
    float mspawnBulletTime;
    int mScore;
    bool mIsOver;
    UIManager ui;
    // Start is called before the first frame update
    void Start()
    {
        mSpawnTime = 0;
        ui = FindObjectOfType<UIManager>();
        ui.SetScoreText("Score: " + mScore);

    }

    // Update is called once per frame
    void Update()
    {
        if (mIsOver)
        {
            mSpawnTime = 0;
            mspawnBulletTime = 0;
            ui.ShowGameoverPanel(true);
            return;
        }

        mSpawnTime -= Time.deltaTime;
        if (mSpawnTime <= 0)
        {
            SpawnEnemy();
            mSpawnTime = spawnTime;
        }
        mspawnBulletTime -= Time.deltaTime;
        if (mspawnBulletTime <= 0)
        {
            SpawnEnemyBullet();
            mspawnBulletTime = spawnBulletTime;
        }
    }
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-2.5f, 2.5f);

        Vector2 spawnPos = new Vector2(randXpos, 6);
        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }
    public void SpawnEnemyBullet()
    {
        float randXpos = Random.Range(-2.5f, 2.5f);

        Vector2 spawnPos = new Vector2(randXpos, 6);
        if (enemyBullet)
        {
            Instantiate(enemyBullet, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void SetScore(int value)
    {
        mScore = value;
    }
    public int GetScore()
    {
        return mScore;
    }
    public void ScoreIncrement()
    {
        mScore++;
        ui.SetScoreText("Score: " + mScore);
    }
    public void SetGameoverState(bool state)
    {
        mIsOver = state;
    }
    public bool IsGameover()
    {
        return mIsOver;
    }
}
