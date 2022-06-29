using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponCollider weaponCollider;

    Animator anim;

    void Start()
    {
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
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack")
            return;

        SetRotation(direction);
        anim.SetTrigger("attack");
    }

    void OnTrigger(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Remove life from enemy
        }
    }
}
