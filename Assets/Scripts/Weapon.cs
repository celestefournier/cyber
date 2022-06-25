using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetTrigger("attack");
        }
    }

    public void SetRotation(Vector2 direction)
    {
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, baseAngle);
    }

    public void Attack()
    {
    }
}
