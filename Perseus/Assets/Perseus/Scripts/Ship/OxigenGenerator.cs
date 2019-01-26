using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public bool isOnFire
        {
            get { return isOnFire; }
            set { isBurning = isOnFire; }
        }

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
    }
}
