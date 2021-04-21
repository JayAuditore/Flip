using UnityEngine;
public class PatrolState : BaseState
{
    public override void OnStateEnter()
    {
        Debug.Log("巡逻Enter");
    }

    public override void OnStateExit()
    {
        Debug.Log("巡逻Exit");
    }

    public override void OnStateStay()
    {
        Debug.Log("巡逻Stay");
    }
}