using UnityEngine;

public class RobotVacuum : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 moveDirection;

    void Start()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        moveDirection = new Vector3(randomDir.x, randomDir.y, 0);
    }

    void Update()
    {

        Vector2 newPos = (Vector2)transform.position + (Vector2)moveDirection * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
    }
}
