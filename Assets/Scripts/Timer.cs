using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Timer
{
    public class TimerController : MonoBehaviour
    {
        public float timer = 0f;
        public TextMeshProUGUI timerText;

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            UpdateTimer();
        }

        void UpdateTimer()
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}