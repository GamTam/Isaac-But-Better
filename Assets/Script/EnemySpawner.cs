using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _spawnTime = 5f;

    private float _currentSpawnTime;
    private float _currentTimer;

    private void Start()
    {
        _currentSpawnTime = _spawnTime;
    }
    
    private void Update()
    {
        _currentTimer += Time.deltaTime;

        if (_currentTimer >= _currentSpawnTime)
        {
            _currentSpawnTime = Random.Range(_spawnTime * 0.5f, _spawnTime * 2f);
            _currentTimer = 0;
            Bounds bounds = GetComponent<Collider2D>().bounds;
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);

            Vector2 spawnPos = transform.position;
            spawnPos.x += offsetX;
            spawnPos.y += offsetY;
            
            EnemyController enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            enemy.SetPointValue();
        }
    }
}
