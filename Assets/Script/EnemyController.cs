using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _timeUntilDespawn = 10f;
    [SerializeField] private int _pointValue;

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

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().PlayerKillCheck();
        }
    }
}
