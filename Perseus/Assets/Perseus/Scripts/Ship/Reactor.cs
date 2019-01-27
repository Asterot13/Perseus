using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
namespace Ship
{
    public class Reactor : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private float max_health;
        [SerializeField]
        private float max_generatingPower;
        [SerializeField]
        private float wearoutIndex;
        public float radiation = 1f;
        private bool isWearingOut = true;

        public float currentGeneratingPower;
        [SerializeField]
        private float health;
        public bool isBurning;
        private bool isEmittingRadiation;
        public bool isFixed;
        public bool isOnFire
        {
            get {  return isBurning; }
            set { isBurning = isOnFire;  }
        }


        public GameObject explosion;
        public GameObject fire;
        public GameObject _break;

        public void getBroken(float damage = 0)
        {
            if(health <= 50f && damage == 0)
            {
                isEmittingRadiation = true;
                isFixed = false;
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }
            else if(damage > 0)
            {
                health -= damage;
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log(gameObject.name + " сломался");
        }

        public void getIgniting(float damage)
        {
            if (health <= 50f)
            {
                isEmittingRadiation = true;
                isFixed = false;
                fire.SetActive(true);
                fire.GetComponent<ParticleSystem>().Play();
            }
            else if (damage > 0)
            {
                health -= damage;
                fire.SetActive(true);
                fire.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log(gameObject.name + " загорелся");
        }

        public IEnumerator getDestroyed()
        {
            explosion.SetActive(true);
            explosion.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(2f);
            FindObjectOfType<EventLaucher>().shipObjectsList.Remove(gameObject);
            Destroy(gameObject);
            Debug.Log(gameObject.name + " взорвался");
        }

        public void getFixed(float fixingSkill)
        {
            if (max_health > health)
            {
                health += fixingSkill;
            }
            else
            {
                print("Object is fixed"); //TODO: Display in UI
                isFixed = true;
            }

            if (isFixed)
            {
                fire.GetComponent<ParticleSystem>().Stop();
                fire.SetActive(false);
                _break.GetComponent<ParticleSystem>().Stop();
                _break.SetActive(false);

            }
        }

        public void takeDamage()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator wearOut()
        {
            isWearingOut = false;
            yield return new WaitForSecondsRealtime(5f);
            health -= wearoutIndex * (isBurning ? 1.5f : 1);
            currentGeneratingPower *= (health / 100);
            isWearingOut = true;
        }

        public IEnumerator emitRadiation()
        {
            isEmittingRadiation = false;
            yield return new WaitForSecondsRealtime(5f);
            _ship.currentRadiationLevel += radiation;
            isEmittingRadiation = true;
        }

        public IEnumerator lowerRadiation()
        {
            isEmittingRadiation = false;
            yield return new WaitForSecondsRealtime(5f);
            _ship.currentRadiationLevel -= radiation;
            isEmittingRadiation = true;
        }

        // Use this for initialization
        void Start()
        {
            health = max_health;
            currentGeneratingPower = max_generatingPower/10;
            isOnFire = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(isWearingOut)
                StartCoroutine(wearOut());
            if ((health <= 50f || isOnFire) && isEmittingRadiation)
                StartCoroutine(emitRadiation());
            if (isFixed && _ship.currentRadiationLevel > 0)
                StartCoroutine(lowerRadiation());
            if (health <= 0)
                StartCoroutine(getDestroyed());
        }
    }
}
