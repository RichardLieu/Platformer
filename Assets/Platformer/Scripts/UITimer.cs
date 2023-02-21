using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public float accumulatedTime = 0f;
    public int totalTime = 100;
    public GameObject timeText;

    private const int TimeStops = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeText.GetComponent<TextMeshProUGUI>().text = "Time\n" + totalTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;

        if (accumulatedTime > 1f)
        {
            totalTime -= 1;
            accumulatedTime = 0f;
            timeText.GetComponent<TextMeshProUGUI>().text = "Time\n" + totalTime.ToString();
            Debug.Log($"Time is {totalTime}");
        }

        else if (totalTime == TimeStops)
        {
            ResetTime();
            timeText.GetComponent<TextMeshProUGUI>().text = "Time\n" + totalTime.ToString();
            Debug.Log("You have failed!");
        }
    }

    private void ResetTime()
    {
        totalTime = 100;
    }
}
