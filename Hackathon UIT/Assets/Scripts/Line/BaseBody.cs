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

    public float hp;        //Máu hiện tại của player
    public float hpCurrent;
    public float speed;
    public float range;
    public Direction dir;
    public GameObject hpBar;
    public LinePlayer line;
    public bool leader;

    protected Animator anim;

    private delegate void Action();
    private Action Move;

    [HideInInspector]
    public List<PathRecorder> recorder;
    [HideInInspector]
    public int number;
    [HideInInspector]
    public LinePlayer linePlayer;
    private int pos;

    private void Start()
    {
        hpCurrent = hp;
        Init();
    }

    private void Update()
    {
        if (leader)
        {
            recorder.Add(new PathRecorder(transform.position, dir));
        }

        Move();
        SetAnimation(this.dir);
    }

    public virtual void Init()
    {
        if (Move != Follow) 
            Move = TurnDown;

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
        transform.position = this.recorder[pos].position;
        dir = this.recorder[pos].direction;
        number++;
    }

    public virtual void OnHit(float damge)
    { }

    public virtual void OnHitLine(int index)
    {
        if (linePlayer)
        {
            linePlayer.OnHitLine(index);
        }
    }

    public virtual void OnDie()
    { }

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

    public virtual void UpdateHp(float d)
    {
        hpCurrent -= d;
        float scale = hpCurrent / hp;
        if (hpCurrent <= 0)
        {
            EffectManager.Instance.Spawn(TYPE_FX.Collision, gameObject.transform.position);
            Destroy(gameObject);
        }
        hpBar.transform.localScale = new Vector3(scale, 1, 1);

    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            OnHitLine(col.GetComponent<BaseBody>().number);
        }
    }

}
