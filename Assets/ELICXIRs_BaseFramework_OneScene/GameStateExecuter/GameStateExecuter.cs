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


    //このGameStateが開始された際に呼ばれます。
    public virtual IEnumerator Init(gamestate before)
    {
        yield break;
    }

    //このGameStateが有効であるとき、Updateの周期に合わせて呼ばれます。
    public virtual void Updater()
    {
    }

    //このGameStateが有効であるとき、LateUpdateの周期に合わせて呼ばれます。
    public virtual void LateUpdater()
    {
    }


    //このGameStateが有効であるとき、FixedUpdateの周期に合わせて呼ばれます。
    public virtual void FixedUpdater()
    {

    }

    //このGameStateが終了する際に呼ばれます。
    public virtual IEnumerator Finalizer(gamestate after)
    {
        yield break;
    }
}
