using System;
using UnityEngine;

public class Orb : MonoBehaviour
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
            other.GetComponent<Enemy>().SetDamage(1, player.position, onKill);
        }
    }
}
