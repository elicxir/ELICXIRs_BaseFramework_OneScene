using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Canvas‹@”\‚ğˆµ‚¦‚é‚æ‚¤‚ÉGameStateExecuter‚ğŠg’£


[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasGroup))]
public class GameStateExecuter_Panel : GameStateExecuter
{
    [SerializeField] protected CanvasGroup CanvasGroup;

    protected RectTransform RectTransform;


    private void OnValidate()
    {
        if (CanvasGroup == null)
        {
            CanvasGroup = GetComponent<CanvasGroup>();

            if (CanvasGroup == null)
            {
                Debug.LogError("CanvasGroupæ“¾‚É–â‘è‚ª”­¶");
            }
        }

        if (RectTransform == null)
        {
            RectTransform = GetComponent<RectTransform>();

            if (RectTransform == null)
            {
                Debug.LogError("RectTransformæ“¾‚É–â‘è‚ª”­¶");
            }
            else
            {
                RectTransform.anchorMin = Vector2.zero;
                RectTransform.anchorMax = Vector2.one;
                RectTransform.offsetMin = Vector2.zero;
                RectTransform.offsetMax = Vector2.zero;
            }
        }

    }

}
