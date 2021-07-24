using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public abstract class State
    {
        protected Enemy enemy;
        protected NPCBaby baby;

        public State(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public State(NPCBaby baby)
        {
            this.baby = baby;
        }

        public abstract void Tick();

        public virtual void OnStateEnter() { }

        public virtual void OnStateExit() { }
    }
}
