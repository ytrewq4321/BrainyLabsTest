using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Score score;

    private Vector2 startPlayerPosition;
    private Vector2 startEnemyPosition;

    void Start()
    {
        startPlayerPosition = player.transform.position;
        startEnemyPosition = enemy.transform.position;

        GlobalEventManager.PlayerDied.AddListener(OnPlayerDied);
        GlobalEventManager.EnemyDied.AddListener(OnEnemyDied);
    }

    public void Restart()
    {
        var bullets =GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
            Destroy(bullets[i]);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = startPlayerPosition;
        enemy.transform.position = startEnemyPosition;
    }

    private void OnPlayerDied()
    {
        score.IncrementEnemyScore();
        Restart();
    }

    private void OnEnemyDied()
    {
        score.IncrementPlayerScore();
        Restart();
    }
}
