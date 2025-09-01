using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public Rigidbody2D bullet;

    public void FireBullet(Vector2 position)
    {
        Instantiate(bullet, position, Quaternion.identity);
    }
    
}
