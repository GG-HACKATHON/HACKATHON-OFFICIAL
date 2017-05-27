using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGameStart : BaseDialog {

	public void onClickPlayGame()
    {
        this.OnHide();
    }
    public void onClickSeting()
    {
        DialogManager.Instance.ShowDialog <DialogGameSeting>("Dialog/Portrait/GameSetting");
    }
}
