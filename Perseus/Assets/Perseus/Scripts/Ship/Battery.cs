using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Ship
{
    public class Battery : MonoBehaviour, IDamageable
    {

        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private Reactor _reactor;

        [SerializeField]
        private float max_capacity;
        [SerializeField]
        private float chargeSpeed;
        [SerializeField]
        private float currentCharge;
        private bool isCharging = true;
        [SerializeField]
        private float max_health;
        [SerializeField]
        private float health;
        public float wearoutIndex;
        public bool isBurning;
        private bool isWearingOut = true;
        public bool isFixed;

        public GameObject explosion;
        public GameObject fire;
        public GameObject _break;

        public bool isOnFire
        {
            get { return isBurning; }
            set { isBurning = isOnFire; }
        }

        public void getBroken(float damage = 0)
        {
            if(health <= 50f && damage == 0)
            {
                //TODO: Battery Needs Fixing
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }
            else if(damage > 0 && health <= 50f)
            {
                //TODO: Show the same as above
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log(gameObject.name + " сломался");
        }

        public void getIgniting(float damage)
        {
            if (health <= 50f)
            {
                //TODO: Battery Needs Fixing
                isBurning = true;
                isFixed = false;
                fire.SetActive(true);
                fire.GetComponent<ParticleSystem>().Play();
            }
            else if (damage > 0)
            {
                //TODO: Show the same as above
                fire.SetActive(true);
                fire.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log(gameObject.name + " загорелся");
        }

        public float getSomeCharge(float request)
        {
            currentCharge -= request;
            return request;
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
            if (health < max_health)
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
            yield return new WaitForSecondsRealtime(30f);
            health -= wearoutIndex * (isBurning ? 1.5f : 1); ;
            isWearingOut = true;
        }

        public IEnumerator charge()
        {
            isCharging = false;
            yield return new WaitForSecondsRealtime(chargeSpeed);
            if (currentCharge > max_capacity)
                currentCharge = max_capacity;
            else
            {
                currentCharge += ((_reactor.currentGeneratingPower) - _ship.energyConsumption);
            }
            isCharging = true;
        }


        // Use this for initialization
        void Start()
        {
            health = max_health;
            currentCharge = max_capacity;
        }

        // Update is called once per frame
        void Update()
        {
            _ship.energy = currentCharge;
            if(isCharging)
                StartCoroutine(charge());

            if (wearoutIndex > 0 && isWearingOut)
                StartCoroutine(wearOut());
            if (health <= 0)
                StartCoroutine(getDestroyed());

        }
    }
}
