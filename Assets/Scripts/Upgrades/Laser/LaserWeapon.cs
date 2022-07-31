using System;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] GameObject contactEffectPrefab;

    Transform player;
    Action<int> onKill;

    public void Init(Transform player, Action<int> onKill)
    {
        this.player = player;
        this.onKill = onKill;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(contactEffectPrefab, other.ClosestPoint(player.position), Quaternion.identity);
            other.GetComponent<Enemy>().SetDamage(2, player.position, onKill);
        }
    }
}
