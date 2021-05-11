using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.StateMachine;
using Flip.AI;

[CreateAssetMenu(fileName = "Is Patroling", menuName = "StateMachine/Conditions/IsPatroling")]

public class IsEnemyPatrolConditionSO : StateConditionSO<IsEnemyPatrolCondition>
{
}

public class IsEnemyPatrolCondition : Condition
{
    #region 字段

    private EnemyInput enemyInput;

    #endregion

    public override void Init(StateMachine stateMachine)
    {
        enemyInput = stateMachine.GetComponent<EnemyInput>();
    }

    public override bool Statement()
    {
        return enemyInput.SwitchCondition();
    }
}