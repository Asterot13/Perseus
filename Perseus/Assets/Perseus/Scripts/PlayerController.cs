using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PersonController unitController;
    public Camera playersCam;
    public Resolution[] resol;
    public LayerMask UnitsMask;

    private void Start()
    {
        resol = Screen.resolutions;
        playersCam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        PickUnit();
        UnPickUnit();
    }

    public void PickUnit()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject activeUnit = GetUnitFromWorldPosition();

            if (activeUnit != null)
            {
                PersonController newUnitController = activeUnit.GetComponent<PersonController>();

                if (unitController != null && unitController != newUnitController)
                {
                    unitController.isActive = false;
                    unitController = newUnitController;
                    unitController.isActive = true;
                }
                else
                {
                    unitController = newUnitController;
                    unitController.isActive = true;
                }
            }
        }
    }

    public GameObject GetUnitFromWorldPosition()
    {
        GameObject retVal = null;
        Ray ray = playersCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, UnitsMask);
        List<GameObject> units = new List<GameObject>();
        //Debug.DrawRay(playersCam.transform.position, Input.mousePosition, Color.red, 3, true);

        for (int i = 0; i < hits.Length; i++)
        {
            GameObject unit = hits[i].collider.gameObject;
            if (unit != null)
            {
                if (unit.tag == "Unit")
                {
                    //PersonController unController = unit.GetComponent<PersonController>();
                    //unitController.isActive = true;
                    units.Add(unit);
                }

                float minDis = Mathf.Infinity;
                for (int j = 0; j < units.Count; j++)
                {
                    float tmpDis = Vector3.Distance(units[j].transform.position,
                        playersCam.transform.position);

                    if (tmpDis < minDis)
                    {
                        minDis = tmpDis;
                        retVal = units[j];
                    }
                }
            }
        }

        return retVal;
    }

    void UnPickUnit()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (unitController != null )
            {
                unitController.isActive = false;
                unitController = null;
            }
        }
    }
}
