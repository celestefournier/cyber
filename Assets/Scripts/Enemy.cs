using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;

    Transform player;
    Rigidbody2D rb;
    float knockbackForce = 0.2f;
    float health = 3;
    
    public void Init(Transform player)
    {
        this.player = player;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var directionBase = player.position - transform.position;
        var direction = directionBase.normalized * moveSpeed;

        rb.velocity = direction;
    }

    public void SetDamage(float damage, Vector3 contactPoint)
	{
        health -= damage;

		if (health <= 0)
			Destroy(gameObject);

        var knockbackPos = (transform.position - contactPoint).normalized;

		rb.DOMove(knockbackPos * knockbackForce + transform.position, 0.2f).SetEase(Ease.Linear);
	}
}
