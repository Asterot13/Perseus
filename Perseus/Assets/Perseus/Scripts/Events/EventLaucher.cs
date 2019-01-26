using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Events
{
    public class EventLaucher : MonoBehaviour
    {
        public List<EventInstance> eventInstances = new List<EventInstance>();

        public float fireFromPrc;
        public float fireToPrc;
        public float damageFromPrc;
        public float damageToPrc;
        public float customFromPrc;
        public float customerToPrc;

        ShipEvent shipEvent;
        public List<GameObject> shipObjectsList;

        private void Start()
        {
            eventInstances.Add(new EventInstance { eventType = EventType.Fire, fromPrc = fireFromPrc, toPrc = fireToPrc });
            eventInstances.Add(new EventInstance { eventType = EventType.Damage, fromPrc = damageFromPrc, toPrc = damageToPrc });
            eventInstances.Add(new EventInstance { eventType = EventType.Custom, fromPrc = customFromPrc, toPrc = customerToPrc });
        }

        private void LaunchEvent()
        {
            int eventPercentage = Random.Range(1, 100);
            EventInstance eventToLaunch = eventInstances.FirstOrDefault(e => e.fromPrc <= eventPercentage && e.toPrc >= eventPercentage);

            int objectIndex = Random.Range(0, shipObjectsList.Count);

            switch(eventToLaunch.eventType)
            {
                case EventType.Custom:
                    shipEvent.callCustomEvent(shipObjectsList[objectIndex]);
                    break;
                case EventType.Damage:
                    shipEvent.damage(shipObjectsList[objectIndex].GetComponent<IDamageable>());
                    break;
                case EventType.Fire:
                    shipEvent.ignite(shipObjectsList[objectIndex].GetComponent<IDamageable>());
                    break;
            }

        }

    }

    public class EventInstance
    {
        public EventType eventType;
        public float fromPrc;
        public float toPrc;
    }

    public enum EventType
    {
        Fire,
        Damage,
        Custom
    }
}
