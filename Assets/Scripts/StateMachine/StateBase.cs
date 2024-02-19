using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase 
{
    public virtual void OnStateEnter(object obj = null) 
    {
        //Debug.Log("OnStateEnter");
    }
    public virtual void OnStateStay()
    {
        //Debug.Log("OnStateStay");
    }
    public virtual void OnStateExit()
    {
        //Debug.Log("OnStateExit");
    }
}

public class StatePlay : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        Ball b = (Ball)o;
        base.OnStateEnter(o);

        GameManager.Instance.StartGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetBall();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ShowEndGameMenu();
    }
}
