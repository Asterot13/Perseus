using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDetails : MonoBehaviour
{
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public string name;
        public Sprite sprite;
        public specialization specialization;
        public GameObject prefab;
}
