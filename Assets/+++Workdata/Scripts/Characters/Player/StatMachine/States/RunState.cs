using UnityEngine;

namespace ___WorkData.Scripts.StateMachine.States
{
    public class RunState : State
    {
        public State idleState;
        public State crawlState;
        
        public override void StateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                End(crawlState);
                return;
            }
            
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                End(idleState);
                return;
            }
        }

        public override void StateFixedUpdate()
        {
            playerController.HandleWalking(playerController.runSpeed);
        }
    }
}