using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : GameStateExecuter
{
    public override IEnumerator Finalizer(gamestate after)
    {
        yield return StartCoroutine(GM.FadeOut(0.3f));
    }

    public override void Updater()
    {
        if(GM.Input.ButtonDown(Control.Right)){
            print("11111");
            GM.StateQueue((int)gamestate.MainGame);
        }
    }

}
