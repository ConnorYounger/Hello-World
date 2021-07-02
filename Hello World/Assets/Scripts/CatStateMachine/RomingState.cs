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
        private float idleCoolDownTimer;

        private bool hasReachedDestination;
        private bool foundIdlePoint;

        private Transform targetPoint;
        private Transform lastTargetPoint;

        private List<Transform> possiblePoints;

        public override void Tick()
        {
            SearchForPlayer();
            ReachedDestinationPoint();

            if (targetPoint)
            {
                if(foundIdlePoint)
                    Debug.DrawLine(enemy.transform.position, targetPoint.position, Color.green);
                else
                    Debug.DrawLine(enemy.transform.position, targetPoint.position, Color.red);
            }

            if(idleCoolDownTimer > 0)
                idleCoolDownTimer -= 1 * Time.deltaTime;
        }

        void SearchForPlayer()
        {
            
        }

        void ReachedDestinationPoint()
        {
            if (targetPoint && Vector3.Distance(enemy.transform.position, targetPoint.transform.position) < destinationPointDistance && !hasReachedDestination)
            {
                hasReachedDestination = true;

                if (!foundIdlePoint)
                    CheckForClosePoints();
                else
                    enemy.SetState(new IdleState(enemy));
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
                    if (point == targetPoint)
                    {
                        lastTargetPoint = targetPoint;
                        //Debug.Log("Last Target point: " + lastTargetPoint);
                    }

                    if (point != lastTargetPoint || point != targetPoint)
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

            Debug.Log("Target Point: " + targetPoint);
            enemy.navAgent.SetDestination(targetPoint.position);

            hasReachedDestination = false;

            if(idleCoolDownTimer <= 0)
                SearchForIdlePoint();
        }

        void SearchForIdlePoint()
        {
            possiblePoints.Clear();

            if (enemy.idlePointCollection)
            {
                // Search for each transform within range
                foreach (Transform point in enemy.idlePointCollection.transform)
                {
                    // If the idle point is within range
                    if (Vector3.Distance(enemy.transform.position, point.position) < pointFindDistance)
                    {
                        // Check to see if the cat can see the idle spot
                        RaycastHit hit;
                        Physics.Raycast(enemy.transform.position, point.position, out hit);

                        Debug.DrawLine(enemy.transform.position, hit.point, Color.green);

                        // If the cat can see the idle point, add it to the list of possible points
                        if(hit.collider != null && hit.collider.transform == point)
                        {
                            possiblePoints.Add(point);
                        }

                        // If there are possible points, find the closest idle spot out of all the possible points
                        if(possiblePoints.Count > 0)
                        {
                            float distance = pointFindDistance;
                            int index = 0;

                            for (int i = 0; i < possiblePoints.Count; i++)
                            {
                                // Compare each possible point's distance
                                if (Vector3.Distance(enemy.transform.position, possiblePoints[i].position) < distance)
                                {
                                    distance = Vector3.Distance(enemy.transform.position, possiblePoints[i].position);
                                    index = i;
                                }
                            }

                            foundIdlePoint = true;

                            // Set the target point to the closest idle point the cat can see
                            targetPoint = possiblePoints[index];
                            enemy.navAgent.SetDestination(targetPoint.position);

                            Debug.Log("FOUND IDLE SPOT: " + targetPoint);
                        }
                    }
                }
            }
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entering Roming State");

            foundIdlePoint = false;
            possiblePoints = new List<Transform>();
            lastTargetPoint = enemy.transform;
            idleCoolDownTimer = enemy.idleCoolDownTime;

            CheckForClosePoints();
        }

        public override void OnStateExit()
        {
            Debug.Log("Exiting Roming State");
        }
    }
}
