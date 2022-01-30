using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : GameStateExecuter_Panel
{
    public override IEnumerator Init(gamestate before)
    {
        CanvasGroup.alpha = 1;
        yield return StartCoroutine(GM.FadeIn(0.3f));
    }



    public override IEnumerator Finalizer(gamestate after)
    {
        yield return StartCoroutine(GM.FadeOut(0.3f));
        CanvasGroup.alpha = 0;
    }
}
