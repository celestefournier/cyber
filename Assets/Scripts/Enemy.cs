using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;

    Transform player;
    Rigidbody2D rb;
    
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
}
