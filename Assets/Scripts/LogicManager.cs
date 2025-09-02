using TMPro;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Rigidbody2D bullet;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bulletsAvailableText;
    public TextMeshProUGUI maxBulletsAvailableText;
    
    private int _score = 0;
    [SerializeField] private int clipSize = 6;
    private int _bulletsFired = 0;

    void Start()
    {
        bulletsAvailableText.text = (clipSize - _bulletsFired).ToString();
        maxBulletsAvailableText.text = clipSize.ToString();
        SpawnEnemy();
    }
    
    public void FireBullet(Vector2 position)
    {
        if (_bulletsFired < clipSize)
        {
            Instantiate(bullet, position, Quaternion.identity);
            SetBulletsFired(1);
        }
    }

    public void SetBulletsFired(int amount)
    {
        _bulletsFired += amount;
        bulletsAvailableText.text = (clipSize - _bulletsFired).ToString();
    }
    
    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(), Quaternion.identity);
    }

    public void SetScore(int score)
    {
        _score += score;
        scoreText.text = _score.ToString();
    }

}
