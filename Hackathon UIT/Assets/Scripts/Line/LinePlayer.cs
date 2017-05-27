using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRecorder
{
    public Vector3 position;
    public Direction direction;

    public PathRecorder(Vector3 position, Direction direction)
    {
        this.position = position;
        this.direction = direction;
    }
}

public class LinePlayer : MonoBehaviour {

    [HideInInspector]
    public BaseBody head;
    public ComradeType leaderType;
    public List<ComradeType> follower;
    [HideInInspector]
    public List<PathRecorder> recorder;
    public int distance;
    public float startDistance;

    protected List<GameObject> bodies = new List<GameObject>();

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        GameObject go = (GameObject)Instantiate(ComradeManager.Instance.GetObjectByType(leaderType), transform);
        head = go.GetComponent<BaseBody>();

        if (head) {
            head.leader = true;
            head.recorder = new List<PathRecorder>();
            recorder = head.recorder;
            head.linePlayer = this;
        }
      
        bodies.Add(go);

        Vector3 pos = head.transform.position;
        pos.y += startDistance * follower.Count * distance;

        for (int i = 0; i <= follower.Count * distance; i++)
        {
            recorder.Add(new PathRecorder(pos, head.dir));
            pos.y -= startDistance;
        }

        for (int i = 0; i < follower.Count; i++)
        {
            AddBody(follower[i], bodies.Count);
        }
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnTurnDown();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnTurnUp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnTurnLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnTurnRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (distance * (bodies.Count) < recorder.Count)
                AddBody(ComradeType.HIPPO, bodies.Count);
        }
    }


    public virtual void OnTurnLeft() 
    {
        head.Turn(Direction.LEFT);
    }

    public virtual void OnTurnRight()
    {
        head.Turn(Direction.RIGHT);
    }

    public virtual void OnTurnUp()
    {
        head.Turn(Direction.UP);
    }

    public virtual void OnTurnDown()
    {
        head.Turn(Direction.DOWN);
    }

    public virtual void CreatePlayer(List<int> bodys)
    { }

    public virtual void AddBody(ComradeType type, int number)
    {
        Vector3 pos = new Vector3(100, 100);
        GameObject body = (GameObject)Instantiate(ComradeManager.Instance.GetObjectByType(type), pos, Quaternion.identity, transform);
        BaseBody baseBody = body.GetComponent<BaseBody>();
        try {
            baseBody.recorder = bodies[0].GetComponent<BaseBody>().recorder;
            baseBody.SetNumber(number, distance);
            baseBody.Turn(Direction.FOLLOW);
        }
        catch (Exception e)
        {
            Debug.Log("Error Create");
        }
        bodies.Add(body);
    }

    public virtual void RemoveBody(int index)
    {
        for (int i = index; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }

        bodies.RemoveRange(index, bodies.Count - index);
    }

    public virtual void OnDie()
    { }

    public virtual void OnHitLine(int index)
    {
        RemoveBody(index);
    }

    public void Record()
    {
        if (head != null)
        {
            recorder.Add(new PathRecorder(head.transform.position, head.dir));
        }
    }
}
