using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 0f;
    [SerializeField] Text CountdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString();
       
    }
}
