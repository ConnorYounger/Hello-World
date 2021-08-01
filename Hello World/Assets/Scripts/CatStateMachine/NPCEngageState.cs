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
            //if (timer < enemy.stateWaitTime)
            //{
            //    timer += Time.deltaTime;
            //    //Debug.Log(timer);
            //}
            //else
            //{
            //    enemy.SetState(new RomingState(enemy));
            //}
        }

        public override void OnStateEnter()
        {
            //Debug.Log("Entering NPCEngage State");

            enemy.navAgent.enabled = false;
            timer = 0;

            if (enemy.currentBaby != null)
            {
                //Debug.Log("Set Baby State");
                //enemy.currentBaby.SetState(new NPCBabyPlay(enemy.currentBaby));
            }

            //Debug.Log("Set Baby State");
            //enemy.currentBaby.SetState(new NPCBabyPlay(enemy.currentBaby));
        }

        public override void OnStateExit()
        {
            //Debug.Log("Exiting NPCEngage State");

            enemy.navAgent.enabled = true;
        }
    }
}
