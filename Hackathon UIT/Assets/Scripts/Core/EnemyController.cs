﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    PANDA
}


public class EnemyController : MonoBehaviour {
   
    [System.Serializable]
    public class EnemyProperty
    {
        public EnemyType type;
        public GameObject enemy;
    }

    Dictionary<EnemyType, GameObject> dict = new Dictionary<EnemyType, GameObject>();
    public List<EnemyProperty> enemies;

    void MakeDictionary()
    {
        foreach (EnemyProperty ep in enemies)
        {
            if (!dict.ContainsKey(ep.type))
            {
                dict.Add(ep.type, ep.enemy);
            }
        }
    }

    void Awake()
    {
        MakeDictionary();
    }

    public GameObject GetEnemyByType(EnemyType type)
    {
        if (dict.ContainsKey(type))
        {
            return dict[type];
        }
        else
        {
            return null;
        }
    }

    public float timeSpawn;
    private float elapsedTimeSpawn;
    public int maxEnemy;
    public GameObject hindrance;

    protected void FixedUpdate()
    {
        if (transform.childCount < maxEnemy)
        {
            elapsedTimeSpawn += Time.fixedDeltaTime;
            if (elapsedTimeSpawn >= timeSpawn)
            {
                elapsedTimeSpawn = 0f;
                CreateEnemy(EnemyType.PANDA, (Direction)Random.Range(1, 4));
            }
        }
    }

    public void CreateEnemy(EnemyType type, Direction dir)
    {
        int count = 5;
        GameObject prefab = GetEnemyByType(type);
        Vector3 temp = prefab.transform.position;
        
        while (count > 0)
        {
            Vector3 pos = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f));
            prefab.transform.position = pos;

            if (CheckIntersect(prefab.GetComponent<SpriteRenderer>().bounds))
            {
                GameObject enemy = (GameObject)Instantiate(GetEnemyByType(type), pos, Quaternion.identity, transform);
                AIMovement component = enemy.GetComponent<AIMovement>();
                component.direction = dir;
                break;
            }
            count--;
        }
       
        prefab.transform.position = temp;
    } 

    public bool CheckIntersect(Bounds bounds)
    {
        foreach (Transform child in hindrance.transform)
        {
            if (child.GetComponent<SpriteRenderer>().bounds.Intersects(bounds))
                return false;
        }
        return true;
    }
}
