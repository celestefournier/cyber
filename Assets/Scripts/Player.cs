using UnityEngine;
// using UnityEngine.Events;

public class Player : MonoBehaviour
{
	// [HideInInspector]
	// public UnityEvent onEnabled;

	[SerializeField] Joystick joystick;

	bool canMove = true;
	float moveBaseSpeed = 0.7f;
	SpriteRenderer sprite;
	Rigidbody2D rb;
	Animator anim;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (canMove)
			Move(joystick.Horizontal, joystick.Vertical);
	}

	public void Move(float horizontal, float vertical)
	{
		var moveDirection = new Vector2(horizontal, vertical);
		var moveSpeed = Mathf.Clamp(moveDirection.magnitude, 0f, 1f);
		var direction = moveDirection.normalized * moveSpeed * moveBaseSpeed;
		var isMoving = direction != Vector2.zero;

		if (isMoving)
		{
			sprite.flipX = direction.x < 0;
		}

		anim.SetBool("walking", isMoving);
		rb.velocity = direction;
	}

	// public void Enabled(bool enabled)
	// {
	// 	canMove = enabled;

	// 	if (enabled)
	// 		onEnabled.Invoke();
	// }
}
