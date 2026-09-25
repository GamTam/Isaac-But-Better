using System;
using UnityEngine;

public class InvinciblePickup : EnemyController
{
    private new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().MakeInvincible();
            Destroy(gameObject);
        }
    }

    public override void SetPointValue()
    {
        return;
    }
}
