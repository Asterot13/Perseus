using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{

    [HideInInspector]
    public NavMeshAgent playerAgent;
    public PersonStats playerStats;
    private bool hasInteracted;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        playerAgent.stoppingDistance = 2f;
    }

    void Update()
    {
        if (playerStats)
        {
            playerStats.interact = hasInteracted;
            if (!playerStats.interact && playerAgent != null && !playerAgent.pathPending)
            {
                if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
                {
                    Interact(playerStats);
                    playerStats.interact = true;
                }
            }
        }
    }

    public virtual void Interact(PersonStats stats)
    {
        Debug.Log("Interacting with base class");
    }

    public virtual void InteractComplete(PersonStats stats)
    {
        hasInteracted = false;
        playerStats.interact = false;
        playerStats = null;
    }
}
