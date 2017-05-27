using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogGameOver : BaseDialog {

    public string score;
    public Text scoreResult;

    public void Start()
    {
        scoreResult.text = score;
    }
    public void onClickReplay()
    {
        this.OnHide();
        //Application.LoadLevel("Main");
    }
    public void onClickHome()
    {
        //Application.LoadLevel("Main");
    }
}
