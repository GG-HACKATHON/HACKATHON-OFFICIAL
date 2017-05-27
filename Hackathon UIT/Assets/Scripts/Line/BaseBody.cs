using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    FOLLOW = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4
}

public class BaseBody : MonoBehaviour {

    public Direction dir;
    public bool leader;
    public GameObject hp;
    public float health;

    public float curHealth;

    protected Animator anim;
    private delegate void Action();
    private Action Move;
    private int pos;
    private float speed = 1f;


    [HideInInspector]
    public List<PathRecorder> recorder;
    [HideInInspector]
    public int number;
    [HideInInspector]
    public LinePlayer linePlayer;

    protected void Start()
    {
        Init();
    }

    protected void FixedUpdate()
    {
        if (leader)
        {
            recorder.Add(new PathRecorder(transform.position, dir));
        }

        Move();
        SetAnimation(dir);
    }

    Action GetAction(Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT: return TurnLeft;
            case Direction.RIGHT: return TurnRight;
            case Direction.UP: return TurnUp;
            case Direction.DOWN: return TurnDown;
            default: return Follow;
        }
    }

    public virtual void Init()
    {
        defaultScale = hp.transform.localScale;
        Move = GetAction(dir);
        curHealth = health;
        if (Move != Follow)
        {
            Move = TurnDown;
        }
         
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Break();
        }
    }

    public virtual void Turn(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                if (dir != Direction.RIGHT)
                {
                    Move = TurnLeft;
                }
                break;
            case Direction.RIGHT:
                if (dir != Direction.LEFT)
                {
                    Move = TurnRight;
                }
                break;
            case Direction.UP:
                if (dir != Direction.DOWN)
                {
                    Move = TurnUp;
                }
                break;
            case Direction.DOWN:
                if (dir != Direction.UP)
                {
                    Move = TurnDown;
                }
                break;
            case Direction.FOLLOW:
                Move = Follow;
                break;
        }
    }

    public virtual void TurnLeft()
    {
        this.dir = Direction.LEFT;
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public virtual void TurnRight()
    {
        this.dir = Direction.RIGHT;
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public virtual void TurnUp()
    {
        this.dir = Direction.UP;
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public virtual void TurnDown()
    {
        this.dir = Direction.DOWN;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public virtual void Follow()
    {
        transform.position = recorder[pos].position;
        dir = recorder[pos].direction;
        pos++;
    }

    Vector3 defaultScale;

    public virtual void OnHit(float dame)
    {
        curHealth -= dame;
        if (curHealth <= 0)
        {
            //Quan test:
            EffectManager.Instance.Spawn(TYPE_FX.Collision, this.transform.position);
           
            OnDie();
        }

        float ratio = curHealth / health;

        Vector3 scale = defaultScale;
        scale.x *= ratio;

        hp.transform.localScale = scale;
    }

    public virtual void OnHit(BaseBody target, float dame)
    {
        target.health -= dame;
    }

    public virtual void OnHitLine(int index)
    {
        if (linePlayer)
        {
            linePlayer.OnHitLine(index);
        }
    }

    public virtual void OnDie()
    {
        if (leader)
        {
            linePlayer.OnDie();
        }
    }

    public virtual void OnAttack()
    { }

    public virtual void SetNumber(int number, int space)
    {
        this.number = number;
        this.pos = this.recorder.Count - number * space;
    }

    public virtual void SetAnimation(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;

            case Direction.RIGHT:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;

            case Direction.UP:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", true);
                anim.SetBool("isDown", false);
                break;

            case Direction.DOWN:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", true);
                break;
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("HitDown"))
            anim.SetBool("isHit", false);
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            OnHitLine(col.GetComponent<BaseBody>().number);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
