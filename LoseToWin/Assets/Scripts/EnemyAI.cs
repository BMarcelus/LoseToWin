using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public List<Vector3> points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    private GameObject player;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.player;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        points.Add(new Vector3(0, 0, 0));

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (!agent.isOnNavMesh)
            return;
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint];

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;
    }


    void Update()
    {
      Vector3 diff = player.transform.position-transform.position;
      if(diff.magnitude<30) {
        diff.y=0;
        Quaternion look = Quaternion.LookRotation(diff);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, 0.05f);
      }
        if (!agent.isOnNavMesh)
            return;
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
