using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _timeUntilDespawn = 10f;
    [SerializeField] private int _pointValue;
    [SerializeField] private GameManager _gameManager;

    protected void Start()
    {
        _gameManager = GameManager.Instance;
    }


    protected void Update()
    {
        _timeUntilDespawn -= Time.deltaTime;
        if (_timeUntilDespawn <= 0) Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().EnemyKillCheck(7, gameObject, _pointValue);
        }
    }

    public virtual void SetPointValue()
    {
        _pointValue = Mathf.RoundToInt(Random.Range(_pointValue * 0.8f, _pointValue * 1.2f));
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            
            if (player.GetInvincible) 
                player.EnemyKillCheck(7, gameObject, _pointValue);
            else 
                player.PlayerKillCheck(transform.position.y - (transform.localScale.y / 2));
        }
    }

    private void OnDestroy()
    {
        if (_gameManager.CurrentState != GameManager.GameState.Gaming)  return;
        
        if (_timeUntilDespawn > 0) _gameManager.Score += _pointValue;
        else _gameManager.Score -= (_pointValue / 4);
    }
}
