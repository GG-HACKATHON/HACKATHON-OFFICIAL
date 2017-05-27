using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGamePause : MonoBehaviour {

    public Toggle sound;
    public Toggle music;
	public void onClickResume()
    { }
    public void onClickExit()
    {
        DialogManager.Instance.ShowMessageBox("Bạn có muốn thoát không?", MESSAGETYPE.YES_NO, () => this.onExit());
    }
    void onExit()
    {

    }
}
