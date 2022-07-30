using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] SwordCollider weaponCollider;

    Action<int> onKillEnemy;
    Animator anim;

    [HideInInspector]
    public bool isAttacking => anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack";

    public void Init(Action<int> onKillEnemy)
    {
        this.onKillEnemy = onKillEnemy;

        anim = GetComponent<Animator>();
        weaponCollider.Init(OnTrigger);
    }

    public void SetRotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
        var isRight = direction.x > 0;

		transform.rotation = Quaternion.Euler(0, isRight ? 0 : 180, angle);
    }

    public void Attack(Vector2 direction)
    {
        if (isAttacking)
            return;

        SetRotation(direction);
        anim.SetTrigger("attack");
    }

    void OnTrigger(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            AudioManager.Instance.Play(Sound.SwordAttack);
            other.GetComponent<Enemy>().SetDamage(1, player.position, onKillEnemy);
        }
    }
}
