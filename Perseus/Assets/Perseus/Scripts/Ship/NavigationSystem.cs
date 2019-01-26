using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ship
{
    public class NavigationSystem : MonoBehaviour
    {
        [SerializeField]
        private Ship _ship;

        public bool isDisrupted = false;
        public bool isAdjusted = true;
        private float adjustment;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isDisrupted)
                StartCoroutine(disruptNavigation());
        }

        public IEnumerator adjustNavigation(float navigationSkill)
        {
            while(_ship.gameObject.transform.rotation != _ship.normalRotation)
            {
                _ship.gameObject.transform.rotation = Quaternion.Lerp(_ship.gameObject.transform.rotation, _ship.normalRotation, Time.deltaTime);
                yield return null;
            }
            isAdjusted = true;
        }

        public IEnumerator disruptNavigation()
        {
            while (_ship.gameObject.transform.rotation != _ship.disruptedRotation)
            {
                _ship.gameObject.transform.rotation = Quaternion.Lerp(_ship.gameObject.transform.rotation, _ship.disruptedRotation, Time.deltaTime);
                yield return null;
            }
            _ship.remainingTime += 120f;
            _ship.currentDistance += 640f;
            isDisrupted = false;
            isAdjusted = false;
        }

    }
}
