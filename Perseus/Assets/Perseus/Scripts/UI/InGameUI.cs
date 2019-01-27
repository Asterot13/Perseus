using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ship;

namespace Ship
{
    public class InGameUI : MonoBehaviour
    {
        public Slider thirst;
        public Slider hunger;
        public Slider energy;
        public Slider health;

        public Image characterImage;
        public TextMeshProUGUI characterName;
        public TextMeshProUGUI characterClass;

        public Ship _ship;
        public TextMeshProUGUI time;

        public GameObject upperBound;
        public GameObject rightBar;
        public GameObject leftBar;

        public GameObject shipStats;
        public GameObject mainStats;
        // Start is called before the first frame update

        public Image radiationIcon;
        public Image fireIcon;

        public Sprite noRadiation;
        public Sprite yesRadiation;

        public Sprite noFire;
        public Sprite yesFire;

        void OnEnable()
        {
            time.text = System.Convert.ToInt32(_ship.remainingTime).ToString();
            rightBar.SetActive(false);
            leftBar.SetActive(false);
            shipStats.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(_ship.currentRadiationLevel > _ship.normalRadiationLevel)
            {
                //TODO: CREATE RADIATION ICON AND FIRE LOGIC
            }
            time.text = System.Convert.ToInt32(_ship.remainingTime).ToString();
        }

        public void showShipStats()
        {
            Time.timeScale = 0;
            shipStats.SetActive(true);
        }

        public void hideShipStats()
        {
            Time.timeScale = 1;
            shipStats.SetActive(false);
        }

    }
}
