using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class NPCEngageState : State
    {
        public NPCEngageState(Enemy enemy) : base(enemy) { }

        private float timer;

        public override void Tick()
        {
            if (timer < enemy.stateWaitTime)
            {
                timer += Time.deltaTime;
                //Debug.Log(timer);
            }
            else
            {
                enemy.SetState(new RomingState(enemy));
            }
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering NPCEngage State");

            enemy.navAgent.SetDestination(enemy.transform.position);
            timer = 0;
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting NPCEngage State");
        }
    }
}
