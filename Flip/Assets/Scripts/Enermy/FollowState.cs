using UnityEngine;
class FollowState : BaseState
{
    public override void OnStateEnter()
    {
        Debug.Log("追逐Enter");
    }

    public override void OnStateExit()
    {
        Debug.Log("追逐Exit");
    }

    public override void OnStateStay()
    {
        Debug.Log("追逐Stay");
    }
}