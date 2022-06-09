using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    
    float followSpeed = 0.2f;

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, followSpeed);
    }
}
