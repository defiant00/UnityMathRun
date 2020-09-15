using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float Jump = 7;
	public float minGroundNormalY = 0.65f;

	private Vector2 velocity;
	private bool isGrounded;

	private BoxCollider2D box;
	private Rigidbody2D body;
	private ContactFilter2D contactFilter;
	private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

	private const float minMoveDistance = 0.001f;
	private const float shellRadius = 0.01f;

	void Start()
	{
		box = GetComponent<BoxCollider2D>();

		body = GetComponent<Rigidbody2D>();
		body.isKinematic = true;

		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
		contactFilter.useLayerMask = true;
	}

	void Update()
	{
		if (GameState.Active)
		{
			if (isGrounded && Input.GetButtonDown("Jump"))
			{
				isGrounded = false;
				velocity.y = Jump;
			}
			else if (Input.GetButtonUp("Jump"))
			{
				velocity.y = Mathf.Min(velocity.y, 0);
			}

			float vert = Input.GetAxis("Vertical");
			if (isGrounded && vert < -0.1f)
			{
				// sploot
				box.offset = new Vector2(0, -0.4f);
				box.size = new Vector2(1, 0.2f);
			}
			else
			{
				box.offset = Vector2.zero;
				box.size = Vector2.one;
			}
		}
	}

	void FixedUpdate()
	{
		// Player physics
		velocity += Physics2D.gravity * Time.fixedDeltaTime;

		isGrounded = false;

		var deltaPosition = velocity * Time.fixedDeltaTime;
		var move = Vector2.up * deltaPosition.y;

		PerformMovement(move);
	}

	void PerformMovement(Vector2 move)
	{
		var distance = move.magnitude;

		if (distance > minMoveDistance)
		{
			// Check if we hit anything in current direction of travel
			var count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
			for (var i = 0; i < count; i++)
			{
				var currentNormal = hitBuffer[i].normal;

				// Is this surface flat enough to land on?
				if (currentNormal.y > minGroundNormalY)
				{
					isGrounded = true;
					currentNormal.x = 0;
				}
				if (isGrounded)
				{
					// How much of our velocity aligns with surface normal?
					var projection = Vector2.Dot(velocity, currentNormal);
					if (projection < 0)
					{
						// Slower velocity if moving against the normal (up a hill).
						velocity -= projection * currentNormal;
					}
				}
				else
				{
					// We are airborne, but hit something, so cancel vertical up and horizontal velocity.
					velocity.x *= 0;
					velocity.y = Mathf.Min(velocity.y, 0);
				}
				// Remove shellDistance from actual move distance.
				var modifiedDistance = hitBuffer[i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}
		}
		body.position += move.normalized * distance;
	}
}
