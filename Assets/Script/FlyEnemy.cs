using UnityEngine;

public class FlyEnemy : EnemyController
{
    [SerializeField] private float _moveSpeed = 5f;

    private void Start()
    {
        if (transform.position.x > 0) _moveSpeed *= -1;
    }
    
    private new void Update()
    {
        Vector3 pos = transform.position;
        pos.x += _moveSpeed * Time.deltaTime;

        transform.position = pos;
        base.Update();
    }
}
