using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;

    Transform player;
    Rigidbody2D rb;
    float knockbackForce = 0.2f;
    
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
        var knockbackPos = (transform.position - contactPoint).normalized;

		rb.DOMove(knockbackPos * knockbackForce + transform.position, 0.1f).SetEase(Ease.Linear);
	}
}
