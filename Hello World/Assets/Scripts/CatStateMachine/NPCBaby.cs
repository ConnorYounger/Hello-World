using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class NPCBaby : MonoBehaviour
    {
        private State currentState;

        public bool coolDown = true;
        public bool isIdle = true;

        public Animator animator;

        [Header("Player")]
        public Transform player;
        public float playTriggerDistance;

        [Header("Cat")]
        public Enemy cat;
        public float catPlayTime = 4;

        void Start()
        {
            currentState = new NPCBabyIdle(this);

            // Find the player
            if (GameObject.Find("Player"))
                player = GameObject.Find("Player").transform;
            else
                Debug.Log("Baby: " + this.gameObject.name + " can't find the player");

            // Find the cat
            //if (GameObject.Find("Cat"))
            //    cat = GameObject.Find("Cat").GetComponent<Enemy>();
            //else
            //    Debug.Log("Baby: " + this.gameObject.name + " can't find the cat");
        }

        void Update()
        {
            currentState.Tick();
        }

        public void SetState(State state)
        {
            currentState.OnStateExit();
            currentState = state;
            currentState.OnStateEnter();
        }
    }
}
