using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int gold;
    public int diamond;

    public void AddGold(int num)
    {
        gold += num;
        Debug.Log("Gold: " + gold);
    }

    public void AddDiamond(int num)
    {
        gold += num;
        Debug.Log("Diamond: " + diamond);
    }

}
