using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class NPCBabyPlay : State
    {
        public NPCBabyPlay(NPCBaby baby) : base(baby) { }

        public float playTime = 5;
        private float playTimer;
        private bool playing;

        public override void Tick()
        {
            if (playing)
            {
                if (playTimer > 0)
                {
                    playTimer -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Return to baby idle");
                    Debug.Log("cat: " + baby.cat);

                    if (baby.cat)
                        baby.cat.SetState(new RomingState(baby.cat));

                    baby.SetState(new NPCBabyIdle(baby));
                }
            }
        }

        void PlayAudioClip()
        {
            int rand = Random.Range(0, baby.audioClips.Length);
            baby.audioSource.clip = baby.audioClips[rand];
            baby.audioSource.Play();
        }

        public override void OnStateEnter()
        {
            Debug.Log("Baby Entering Play State");
            playTimer = playTime;
            playing = true;
            baby.isIdle = false;

            PlayAudioClip();

            if (baby.animator)
                baby.animator.SetBool("isPlaying", true);
        }

        public override void OnStateExit()
        {
            if (baby.animator)
                baby.animator.SetBool("isPlaying", true);

            playing = false;
            Debug.Log("Baby Exiting Play State");
        }
    }
}
