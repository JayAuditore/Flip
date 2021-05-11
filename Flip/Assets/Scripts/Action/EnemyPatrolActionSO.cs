using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.StateMachine;
using Flip.AI;

[CreateAssetMenu(fileName = "Enemy Patrol Action", menuName = "FSM/EnemyPatrolActionSO")]

public class EnemyPatrolActionSO : StateActionSO<EnemyPatrolAction>
{

}

public class EnemyPatrolAction : StateAction
{
    #region 字段

    private EnemyInput enemyInput;

    #endregion
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
    public override void Init(StateMachine stateMachine)
    {
        enemyInput = stateMachine.GetComponent<EnemyInput>();
    }

    public override void OnUpdate()
    {
        enemyInput.EnemyPatrol();
    }
}