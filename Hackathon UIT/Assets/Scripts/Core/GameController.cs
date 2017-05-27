using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{

    public Text txtDiamond;

    public int gold;
    public int diamond;

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

}
