using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Rigidbody2D bullet;

    void Start()
    {
        SpawnEnemy();
    }
    
    public void FireBullet(Vector2 position)
    {
        Instantiate(bullet, position, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(), Quaternion.identity);
    }
    
}
