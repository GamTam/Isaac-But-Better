using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _spawnTime = 5f;


    private float _currentTimer;

    private void Update()
    {
        _currentTimer += Time.deltaTime;

        if (_currentTimer >= _spawnTime)
        {
            _currentTimer = 0;
            Bounds bounds = GetComponent<Collider2D>().bounds;
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);

            Vector2 spawnPos = transform.position;
            spawnPos.x += offsetX;
            spawnPos.y += offsetY;
            
            Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
