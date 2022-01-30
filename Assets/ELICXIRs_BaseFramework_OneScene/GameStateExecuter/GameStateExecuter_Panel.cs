using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Canvas�@�\��������悤��GameStateExecuter���g��


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
                Debug.LogError("CanvasGroup�擾�ɖ�肪����");
            }
        }

        if (RectTransform == null)
        {
            RectTransform = GetComponent<RectTransform>();

            if (RectTransform == null)
            {
                Debug.LogError("RectTransform�擾�ɖ�肪����");
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
