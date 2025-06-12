using ___WorkData.Scripts.StateMachine;
using UnityEngine;

public class IdleState : State
{

    public State crawlState;
    public State crouchState;
    public State walkState;
    public State runState;
    
    public override void StateUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            End(crawlState);
        }
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                End(runState);
                return;
            }
            
            if (Input.GetKey(KeyCode.LeftControl)) {
                End(crouchState);
                return;
            }
            
            End(walkState);
        }
    }
}
