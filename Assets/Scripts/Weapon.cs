using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public void SetRotation(Vector2 direction)
    {
        print(direction);
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
		transform.rotation = Quaternion.Euler(0, 0, baseAngle);
    }

    public void Attack()
    {
    }
}
