using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateExecuter : MonoBehaviour
{
    public GameManager GM
    {
        get
        {
            return GameManager.Game_Manager;
        }
    }


    //����GameState���J�n���ꂽ�ۂɌĂ΂�܂��B
    public virtual IEnumerator Init(gamestate before)
    {
        yield break;
    }

    //����GameState���L���ł���Ƃ��AUpdate�̎����ɍ��킹�ČĂ΂�܂��B
    public virtual void Updater()
    {
    }

    //����GameState���L���ł���Ƃ��ALateUpdate�̎����ɍ��킹�ČĂ΂�܂��B
    public virtual void LateUpdater()
    {
    }


    //����GameState���L���ł���Ƃ��AFixedUpdate�̎����ɍ��킹�ČĂ΂�܂��B
    public virtual void FixedUpdater()
    {

    }

    //����GameState���I������ۂɌĂ΂�܂��B
    public virtual IEnumerator Finalizer(gamestate after)
    {
        yield break;
    }
}
