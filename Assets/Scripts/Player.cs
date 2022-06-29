using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] Joystick joystick;
	[SerializeField] Weapon sword;

	bool canMove = true;
	float moveBaseSpeed = 0.7f;
	List<Transform> enemiesNearby = new List<Transform>();
	SpriteRenderer sprite;
	Animator anim;
	Rigidbody2D rb;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (canMove)
		{
			Move(joystick.Horizontal, joystick.Vertical);
			CheckEnemyAround();
		}
	}

	public void Move(float horizontal, float vertical)
	{
		var moveDirection = new Vector2(horizontal, vertical);
		var moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0f, 1f);
		var direction = moveDirection.normalized * moveSpeed * moveBaseSpeed;
		var isMoving = direction != Vector2.zero;

		if (isMoving)
		{
			if (enemiesNearby.Count <= 0)
				sword.SetRotation(direction);

			sprite.flipX = direction.x < 0;
		}

		anim.SetBool("walking", isMoving);
		rb.velocity = direction;
	}

	void CheckEnemyAround()
	{
		if (enemiesNearby.Count <= 0)
			return;

		Transform closestEnemy = null;

		foreach (var enemy in enemiesNearby)
		{
			if (closestEnemy == null)
			{
				closestEnemy = enemy;
				continue;
			}

			if (Vector2.Distance(transform.position, enemy.position) < Vector2.Distance(transform.position, closestEnemy.position))
			{
				closestEnemy = enemy;
			}
		}

		sword.Attack(closestEnemy.position - transform.position);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" && !enemiesNearby.Contains(other.transform))
		{
			enemiesNearby.Add(other.transform);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Enemy" && enemiesNearby.Contains(other.transform))
		{
			enemiesNearby.Remove(other.transform);
		}
	}
}
