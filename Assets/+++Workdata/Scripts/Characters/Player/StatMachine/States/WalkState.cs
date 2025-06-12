using UnityEngine;

namespace ___WorkData.Scripts.StateMachine.States
{
    public class WalkState : State
    {
        public State crouchState;
        public State crawlState;
        public State idleState;
        public State runState;
        
        public override void StateUpdate()
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                End(runState);
                return;
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                End(crouchState);
                return;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                End(crawlState);
                return;
            }
            
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                End(idleState);
                
                return;
            }
        }

        public override void StateFixedUpdate()
        {
            playerController.HandleWalking(playerController.walkSpeed);
        }
    }
}