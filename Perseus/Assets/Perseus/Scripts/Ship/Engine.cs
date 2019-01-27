using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Ship
{
    public class Engine : MonoBehaviour, IDamageable
    {

        [SerializeField]
        private Ship _ship;

        //[SerializeField]
        //private float max_power;
        [SerializeField]
        private float max_health;

        //private float power;
        [SerializeField]
        private float health;
        private const float acceleration = 1.5f;
        private bool isWearingOut = true;
        private bool isAccelerating;
        public bool isFixed;

        public bool isBurning;

        public bool isOnFire
        {
            get { return isBurning; }
            set { isBurning = isOnFire; }
        }

        public GameObject explosion;
        public GameObject fire;
        public GameObject _break;

        [SerializeField]
        private float wearingOutIndex;

        public void getBroken(float damage)
        {
            if (health <= 50f && damage == 0)
            {
                //TODO: Battery Needs Fixing
                isFixed = false;
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();

            }
            else if (damage > 0 && health <= 50f)
            {
                //TODO: Show the same as above
                health -= damage;
                _break.SetActive(true);
                _break.GetComponent<ParticleSystem>().Play();
            }
            Debug.Log(gameObject.name + " сломался");
        }

        public void getSpeed()
        {
            _ship.speed = _ship.MAIN_DISTANCE / (_ship.MAIN_TIME/60) * (isAccelerating ? acceleration : 1);
        }

        public void accelerate(bool OnOff)
        {
            isAccelerating = OnOff;
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
            health -= (wearingOutIndex * (isBurning ? 1.5f : 1)) * (isAccelerating ? acceleration : 1);
            isWearingOut = true;
        }

        // Use this for initialization
        void Start()
        {
            health = max_health;
        }

        // Update is called once per frame
        void Update()
        {
            getSpeed();
            if (isWearingOut)
                StartCoroutine(wearOut());

            if (health <= 0)
            {
                StartCoroutine(getDestroyed());
            }
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
