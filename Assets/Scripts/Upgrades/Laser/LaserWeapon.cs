using System;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    Transform player;
    Action<float> onKill;

    public void Init(Transform player, Action<float> onKill)
    {
        this.player = player;
        this.onKill = onKill;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().SetDamage(2, player.position, onKill);
        }
    }
}