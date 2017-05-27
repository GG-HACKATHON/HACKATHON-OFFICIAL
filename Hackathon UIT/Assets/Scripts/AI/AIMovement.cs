using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public float speed;
    public Direction direction;

    delegate void Action();
    Action Move;

    protected virtual void Start()
    {
        Move = GetAction(direction);
    }

	protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            ChangeDirection();
        }
    }

    // AI Execute
    protected virtual void MoveLeft()
    {
        direction = Direction.LEFT;
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
    protected virtual void MoveRight()
    {
        direction = Direction.RIGHT;
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
    protected virtual void MoveUp()
    {
        direction = Direction.UP;
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
    protected virtual void MoveDown()
    {
        direction = Direction.DOWN;
        transform.position += Vector3.left * speed * Time.fixedDeltaTime;
    }
    protected virtual void Stand()
    {

    }
    Action GetAction(Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT: return MoveLeft;
            case Direction.RIGHT: return MoveLeft;
            case Direction.UP: return MoveLeft;
            case Direction.DOWN: return MoveLeft;
            default: return Stand;
        }
    } 

    //--------------------------------AI actions

    // Đổi hướng khi gặp vật cản
    protected virtual void ChangeDirection()
    {
      
    }

    // Đánh khi gặp player
    protected virtual void Attack()
    {

    }

    // Chạy khi gặp player
    protected virtual void Run()
    {

    }
}
