using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Ship
{
    public class OxigenGenerator : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private Ship _ship;
        [SerializeField]
        private Battery _battery;
        [SerializeField]
        private float max_health;

        private float health;
        private bool isWearingOut = true;
        private bool isRestoring = true;
        [SerializeField]
        private float wearingOutIndex;
        [SerializeField]
        private float restoreSpeed;
        public float wearoutIndex;
        public bool isBurning;
        public bool isFixed;

        public GameObject explosion;
        public GameObject fire;
        public GameObject _break;

        public bool isOnFire
        {
            get { return isBurning; }
            set { isBurning = isOnFire; }
        }

        public void getBroken(float damage)
        {
            if (health <= 50f && damage == 0)
            {
                //TODO: Battery Needs Fixing
                //TODO: Battery Needs Fixing
                isFixed = false;
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }
            else if (damage > 0)
            {
                //TODO: Show the same as above
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }

            Debug.Log(gameObject.name + " сломался");
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
                health += fixingSkill;
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
            isWearingOut = true;
        }

        public IEnumerator restore()
        {
            isRestoring = false;
            yield return new WaitForSecondsRealtime(restoreSpeed);
            if (_ship.shipShield > _ship.max_shipShield)
                _ship.shipShield = _ship.max_shipShield;
            else
            {
                _ship.shipShield += _battery.getSomeCharge(restoreSpeed);
            }
            isRestoring = true;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isWearingOut)
                StartCoroutine(wearOut());
            if (isRestoring)
                StartCoroutine(restore());
        }

        public void getIgniting(float damage)
        {
            if (health <= 50f)
            {
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
    }
}
