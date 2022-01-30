using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : GameStateExecuter_Panel
{

    public override IEnumerator Init(gamestate before)
    {
        CanvasGroup.alpha = 1;
        yield return null;
    }



    public override IEnumerator Finalizer(gamestate after)
    {
        yield return StartCoroutine(GM.FadeOut(0.3f));
        CanvasGroup.alpha = 0;
    }

    public override void Updater()
    {
        if(GM.Input.ButtonDown(Control.Button1)){
            GM.StateQueue((int)gamestate.MainGame);
        }
    }

}
