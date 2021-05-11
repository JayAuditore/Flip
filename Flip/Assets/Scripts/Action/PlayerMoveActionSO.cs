using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.StateMachine;
using Flip.PlayerControll;

[CreateAssetMenu(fileName = "Player Move Action", menuName = "FSM/PlayerMoveActionSO")]

public class PlayerMoveActionSO : StateActionSO<PlayerMove>
{

}

public class PlayerMove : StateAction
{
    public override void OnUpdate()
    {

    }
}