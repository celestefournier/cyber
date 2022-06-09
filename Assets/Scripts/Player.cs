using UnityEngine;
// using UnityEngine.Events;

public class Player : MonoBehaviour
{
    // [HideInInspector]
	// public UnityEvent onEnabled;

    bool canMove = true;
	float moveBaseSpeed = 0.7f;
	SpriteRenderer sprite;
	Rigidbody2D rb;
	// Animator anim;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		// anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (canMove)
			Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	public void Move(float horizontal, float vertical)
	{
		var moveDirection = new Vector2(horizontal, vertical);
		var moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0f, 1f);
		moveDirection.Normalize();

		var direction = moveDirection * moveSpeed * moveBaseSpeed;

		bool moveRight = direction.x > 0 || direction.y != 0;
		bool moveLeft = direction.x < 0 || direction.y != 0;

		// anim.SetBool("walking", !sprite.flipX && moveRight || sprite.flipX && moveLeft);
		// anim.SetBool("walkingBack", (sprite.flipX && moveRight || !sprite.flipX && moveLeft) && direction.x != 0);

		rb.velocity = direction;
	}

	// public void Enabled(bool enabled)
	// {
	// 	canMove = enabled;

	// 	if (enabled)
	// 		onEnabled.Invoke();
	// }
}