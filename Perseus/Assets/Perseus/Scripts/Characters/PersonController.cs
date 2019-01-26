using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonController : MonoBehaviour {

    NavMeshAgent playersAgent;
    PersonStats playerStats;
    Interactable interObject;

    public float baseStepHunger;
    public float baseStepThirst;
    public float baseStepEnergy;

    void Start()
    {
        playersAgent = GetComponent<NavMeshAgent>();
        playerStats = GetComponent<PersonStats>();

        baseStepHunger = playerStats.stepHunger;
        baseStepThirst = playerStats.stepThirst;
        baseStepEnergy = playerStats.stepEnergy;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
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
