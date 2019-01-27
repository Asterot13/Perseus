using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonController : MonoBehaviour {

    NavMeshAgent playersAgent;
    PersonStats playerStats;
    Interactable interObject;
    Animator anim;

    float baseStepHunger;
    float baseStepThirst;
    float baseStepEnergy;

    public bool isActive;

    void Start()
    {
        playersAgent = GetComponent<NavMeshAgent>();
        playerStats = GetComponent<PersonStats>();
        anim = gameObject.GetComponent<Animator>();

        baseStepHunger = playerStats.stepHunger;
        baseStepThirst = playerStats.stepThirst;
        baseStepEnergy = playerStats.stepEnergy;
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                GetInteraction();
            }

            if (!playersAgent.hasPath && !playerStats.interact)
            {
                playerStats.idle = true;
                playerStats.walk = false;
                playerStats.run = false;
            }
            else if (playersAgent.hasPath && !playerStats.interact)
            {
                playerStats.idle = false;
                playerStats.walk = true;
                playerStats.run = false;
                //playersAgent.speed = 0.90f;
            }
            else if (!playersAgent.hasPath && playerStats.interact)
            {
                playerStats.idle = false;
                playerStats.walk = false;
                playerStats.run = false;
            }
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObj = interactionInfo.collider.gameObject;
            if (interactedObj.tag == "InteractableObj")
            {
                interactedObj.GetComponent<Interactable>().MoveToInteraction(playersAgent);
                interactedObj.GetComponent<Interactable>().playerStats = this.playerStats;
                interactedObj.GetComponent<Interactable>().anim = this.anim;
                interObject = interactedObj.GetComponent<Interactable>();
                Debug.Log("Interactible interacted");
            }
            else
            {
                if (playerStats.interact)
                {
                    SetBaseStats();
                    interObject.InteractComplete(playerStats);
                }

                playersAgent.stoppingDistance = 0f;
                playersAgent.destination = interactionInfo.point;
                playerStats.interact = false;
            }
        }
    }

    void SetBaseStats()
    {
        playerStats.stepHunger = baseStepHunger;
        playerStats.stepThirst = baseStepThirst;
        playerStats.stepEnergy = baseStepEnergy;
    }
}
