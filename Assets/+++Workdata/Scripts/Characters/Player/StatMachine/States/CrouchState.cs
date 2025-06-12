using UnityEngine;

namespace ___WorkData.Scripts.StateMachine.States
{
    public class CrouchState : State
    {

        public State idleState;
        
        public override void StateUpdate()
        {
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                End(idleState);
            }
        }

        public override void StateFixedUpdate()
        {
            playerController.HandleWalking(playerController.crouchSpeed);
        }
    }
}