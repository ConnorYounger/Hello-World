using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class RomingState : State
    {
        public RomingState(Enemy enemy) : base(enemy) { }

        private float pointFindDistance = 8;
        private float destinationPointDistance = 1f;

        private bool hasReachedDestination;

        private Transform targetPoint;
        private Transform lastTargetPoint;

        private List<Transform> possiblePoints;

        public override void Tick()
        {
            SearchForPlayer();
            ReachedDestinationPoint();
        }

        void SearchForPlayer()
        {

        }

        void ReachedDestinationPoint()
        {
            if (targetPoint && Vector3.Distance(enemy.transform.position, targetPoint.transform.position) < destinationPointDistance && !hasReachedDestination)
            {
                hasReachedDestination = true;

                CheckForClosePoints();
            }
        }

        void CheckForClosePoints()
        {
            possiblePoints.Clear();

            // Search for each transform within range
            foreach (Transform point in enemy.wanderPointCollection.transform)
            {
                if (Vector3.Distance(enemy.transform.position, point.position) < pointFindDistance)
                {
                    possiblePoints.Add(point);
                }
            }

            if (possiblePoints.Count > 0)
            {
                // Pick a random transform 

                int rand = Random.Range(0, possiblePoints.Count);

                targetPoint = possiblePoints[rand];
            }
            else
            {
                // Find the closest transform if there are none in range

                float distance = 100;
                int index = 0;

                for (int i = 0; i < enemy.wanderPointCollection.transform.childCount; i++)
                {
                    if (Vector3.Distance(enemy.transform.position, enemy.wanderPointCollection.transform.GetChild(i).position) < distance)
                    {
                        distance = Vector3.Distance(enemy.transform.position, enemy.wanderPointCollection.transform.GetChild(i).position);
                        index = i;
                    }
                }

                targetPoint = enemy.wanderPointCollection.transform.GetChild(index);
            }

            enemy.navAgent.SetDestination(targetPoint.position);

            hasReachedDestination = false;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Roming State");

            possiblePoints = new List<Transform>();

            lastTargetPoint = enemy.transform;

            CheckForClosePoints();
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Roming State");
        }
    }
}
