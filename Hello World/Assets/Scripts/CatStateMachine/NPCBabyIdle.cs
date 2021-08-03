using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class NPCBabyIdle : State
    {
        public NPCBabyIdle(NPCBaby baby) : base(baby) { }

        public float coolDownTime = 3;
        private float coolDownTimer;
        public bool coolDown = true;

        public override void Tick()
        {
            //Debug.Log("Baby CoolDown");

            if(coolDown)
            {
                if(coolDownTimer > 0)
                    coolDownTimer -= Time.deltaTime;
                else
                {
                    coolDownTimer = 0;
                    coolDown = false;
                    baby.coolDown = false;
                }
            }

            if (coolDown)
            {
                if(Vector3.Distance(baby.transform.position, baby.player.position) < baby.playTriggerDistance)
                {
                    baby.SetState(new NPCBabyIdle(baby));
                }
            }
        }

        public override void OnStateEnter()
        {
            //Debug.Log("Entering Idle State");

            coolDownTimer = coolDownTime;
            coolDown = true;
            baby.coolDown = true;
            baby.isIdle = true;
        }

        public override void OnStateExit()
        {
            //Debug.Log("Exiting Idle State");
        }
    }
}
