using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{

    public bool isRun;

    public Text txtDiamond;

    public int gold;
    public int diamond;
    void Start()
    {
        gold = 0;
        txtDiamond.text = gold.ToString();
    }

    public void AddGold(int num)
    {
        gold += num;
        Debug.Log("Gold: " + gold);

    }

    public void AddDiamond(int num)
    {
        diamond += num;
        Debug.Log("Diamond: " + diamond);
        txtDiamond.text = diamond.ToString();
    }

    [ContextMenu("StartGame")]
    public void StartGame()
    {
        isRun = true;
    }


    public void StopGame()
    {
        isRun = false;
    }

}
