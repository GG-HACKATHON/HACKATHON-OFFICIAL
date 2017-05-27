using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComradeType
{
    PANDA = 0,
    HIPPO = 1,
    ROCKMAN = 2,
}
public class ComradeManager : MonoSingleton<ComradeManager> {

    [System.Serializable]
    public class ComradeProperty
    {
        public ComradeType type;
        public GameObject comrade;
    }

    public List<ComradeProperty> comrades;
    Dictionary<ComradeType, GameObject> dict = new Dictionary<ComradeType, GameObject>();

    private void Awake()
    {
        MakeDictionary();
    }

    private void MakeDictionary()
    {
        foreach (ComradeProperty cp in comrades)
        {
            if (!dict.ContainsKey(cp.type))
            {
                dict.Add(cp.type, cp.comrade);
            }
        }
    }

    public GameObject GetObjectByType(ComradeType type)
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

    public int GetLength()
    {
        return comrades.Count;
    }
}
