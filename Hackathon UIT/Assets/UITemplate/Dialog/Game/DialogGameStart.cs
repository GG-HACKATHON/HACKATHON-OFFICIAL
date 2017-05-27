using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGameStart : BaseDialog {

	public void onClickPlayGame()
    {
        this.OnHide();
        //Application.LoadLevel("Main");
    }
    public void onClickSeting()
    {
        DialogManager.Instance.ShowDialog <DialogGameSetting>("Prefabs/UI/GameSetting");
    }
}
