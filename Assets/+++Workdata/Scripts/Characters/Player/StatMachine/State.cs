using System;
using UnityEngine;

namespace ___WorkData.Scripts.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        public State nextState;
        
        public PlayerController playerController;

        protected bool endCalled;
        public virtual void Enter() {}

        public void Start()
        {
            playerController = GetComponent<PlayerController>();
        }

        public virtual void StateUpdate() { }

        public virtual void StateFixedUpdate() { }

        public virtual void Exit() {}
    
        public void End(State state)
        {
            endCalled = true;

            if (nextState == null)
            {
                if (state == null)
                {
                    throw new ArgumentNullException("State");
                }
                
                nextState = state;
                Exit();
            }
        }

        public void reset()
        {
            endCalled = false;
        }

        public bool getEndCalled()
        {
            return endCalled;
        }
    }
}