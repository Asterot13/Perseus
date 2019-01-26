using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public bool isBurning;

        public bool isOnFire
        {
            get { return isOnFire; }
            set { isBurning = isOnFire; }
        }

        [SerializeField]
        private float wearingOutIndex;

        public void getBroken(float damage)
        {
            if (health <= 50f && damage == 0)
            {
                //TODO: Battery Needs Fixing
            }
            else if (damage > 0 && health <= 50f)
            {
                //TODO: Show the same as above
            }
        }

        public void getSpeed()
        {
            _ship.speed = _ship.MAIN_DISTANCE / (_ship.MAIN_TIME/60) * (isAccelerating ? acceleration : 1);
        }

        public void accelerate(bool OnOff)
        {
            isAccelerating = OnOff;
        }

        public void getDestroyed()
        {
            throw new System.NotImplementedException();
        }

        public void getFixed(float fixingSkill)
        {
            if (max_health > health)
                health += fixingSkill;
            else
                print("Object is fixed"); //TODO: Display in UI
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
        }

    }
}
