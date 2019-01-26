using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStats : MonoBehaviour {
    public Animator anim;

    public float hunger;
    public float thirst;
    public float energy;
    public float stress;
    public float life;

    public float stepHunger;
    public float stepThirst;
    public float stepEnergy;

    public bool idle;
    public bool walk;
    public bool run;
    public bool sleep;
    public bool work;
    public bool interact;
    public bool inSpace;

    private bool setChanges = true;
    private int maxHunger = 100;
    private int maxThirst = 100;
    private float maxEnergy = 100.0f;
    private float maxStress = 0.0f;
    private int maxLife = 100;

    public void ChangeHunger(float _hunger)
    {
        hunger += _hunger;
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
        else if (hunger <= 0)
        {
            Debug.Log("Персонаж" + gameObject.name + " умер от голода");
            Destroy(gameObject);
        } 
    }

    public void ChangeThirst(float _thirst)
    {
        thirst += _thirst;
        if (thirst > maxThirst)
        {
            thirst = maxThirst;
        }
        else if (thirst <= 0)
        {
            Debug.Log("Персонаж" + gameObject.name + " умер от жажды");
            Destroy(gameObject);
        }
    }

    public void ChangeEnergy(float _energy)
    {
        energy += _energy;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        else if (energy <= 0)
        {
            Debug.Log("Персонаж" + gameObject.name + " упал в обморок");
            //Destroy(gameObject);
        }
    }

    public void ChangeStress(float _stress)
    {
        stress += _stress;
        if (stress >= maxStress)
        {
            Debug.Log("Персонаж" + gameObject.name + " впал в безумие");
        }
    }

    public void ChangeLife(float _life)
    {
        life += _life;
        if (life >= maxLife)
        {
            
        }
        else if (life <= 0)
        {
            Debug.Log("Персонаж" + gameObject.name + " умер от ран");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        idle = true;
    }

    void Update()
    {
        if(setChanges)
            StartCoroutine(StatsByTime());

        if (!interact)
        {
            sleep = false;
            work = false;
        }
    }

    IEnumerator StatsByTime()
    {
        setChanges = false;
        ChangeHunger(stepHunger);
        ChangeThirst(stepThirst);
        ChangeEnergy(stepEnergy);
        yield return new WaitForSeconds(1.0f);
        setChanges = true;
    }
}
