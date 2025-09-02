using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    public Rigidbody2D bullet;
    private LogicManager _logicManager;
    private readonly float _moveSpeed = 6.0f;
    private readonly float _deadZone = 6f;

    void Start()
    {
        _logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet.position += Vector2.up * (_moveSpeed * Time.deltaTime);
        if (bullet.position.y > _deadZone)
        {
            Destroy(gameObject);
            _logicManager.SetBulletsFired(-1);
        }
        
    }
}
