using UnityEngine;

namespace ___WorkData.Scripts.StateMachine.States
{
    public class CrawlState : State
    {

        public State idleState;
        
        public override void Enter()
        {
            playerController.HandleCrawling();
        }

        public override void StateUpdate()
        {
            playerController.HandleWalking(playerController.crawlSpeed);
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                End(idleState);
            }
        }

        public override void Exit()
        {
            playerController.HandleCrawling();
        }
    }
}