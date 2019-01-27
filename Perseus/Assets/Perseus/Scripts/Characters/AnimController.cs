using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public float stepBlendIdle;
    public float stepBlendMove;

    public float stepIdle;
    public float stepMove;

    PersonStats stats;
    Animator anim;

    private void Start()
    {
        stats = gameObject.GetComponent<PersonStats>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (stats.idle && !stats.inSpace)
        {
            if (stepIdle > 0.0f)
                stepIdle -= Time.deltaTime * stepBlendIdle;

            if (stepMove > -1.0f)
                stepMove -= Time.deltaTime * stepBlendMove;

            anim.SetFloat("Idle_SpaceIdle", Mathf.Lerp(0.0f, 1.0f, stepIdle));
            anim.SetFloat("Idle_Walk", Mathf.Lerp(-1.0f, 1.0f, stepMove));
        }

        if(stats.idle && stats.inSpace) 
        {
            if (stepIdle < 1.0f)
                stepIdle += Time.deltaTime * stepBlendIdle;

            if (stepMove > -1.0f)
                stepMove -= Time.deltaTime * stepBlendMove;

            anim.SetFloat("Idle_SpaceIdle", Mathf.Lerp(0.0f, 1.0f, stepIdle));
            anim.SetFloat("Idle_Walk", Mathf.Lerp(-1.0f, 1.0f, stepMove));
        }

        if (stats.walk && !stats.inSpace)
        {
            if (stepIdle > 0.0f)
                stepIdle -= Time.deltaTime * stepBlendIdle;

            if (stepMove < 0.0f)
            {
                stepMove += Time.deltaTime * stepBlendMove;
                //stepMove = Mathf.Lerp(-1.0f, 0.0f, Time.deltaTime * 2.0f); //TODO: Разобраться
            }

            anim.SetFloat("Idle_SpaceIdle", Mathf.Lerp(0.0f, 1.0f, stepIdle));
            anim.SetFloat("Idle_Walk", 0.0f);
        }

        if (stats.walk && stats.inSpace)
        {
            if (stepIdle < 0.0f)
                stepIdle += Time.deltaTime * stepBlendIdle;

            if (stepMove < 0.0f)
                stepMove += Time.deltaTime * stepBlendMove;

            //else if (stepMove > 0.0f)
            //    stepMove -= Time.deltaTime * stepBlendMove;

            anim.SetFloat("Idle_SpaceIdle", Mathf.Lerp(0.0f, 1.0f, stepIdle));
            anim.SetFloat("Idle_Walk", 0.0f);
        }

        if (stats.run)
        {
            if (stepIdle > 0.0f)
                stepIdle -= Time.deltaTime * stepBlendIdle;

            if (stepMove < 1.0f)
            {
                stepMove += Time.deltaTime * stepBlendMove;
            }

            anim.SetFloat("Idle_SpaceIdle", Mathf.Lerp(0.0f, 1.0f, stepIdle));
            anim.SetFloat("Idle_Walk", 1.0f);
        }
    }
}
