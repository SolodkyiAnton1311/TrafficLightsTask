using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    //Current script is responsible for management traffic light
    //Scriptable Object Data
    [SerializeField] private TrafficLightData _trafficLighData;
    //List of Traffic Lights
    [SerializeField] private List<TrafficLight> trafficLights;
   
    //Variable to indicate which traffic light is currently running
    //For the start it is 0 , but in the future you can implement the recording of the last traffic light 
    private int _currentTrafficLight;
    //Declaration delays 
    private float _delayGreenToAmberLight;
    private float _delayRedToAmberLight;
    private float _delayAmberToGreenLight;
    private float _delayAmberToRedLight;


    private void Awake()
    {
        _delayAmberToGreenLight = _trafficLighData._delayAmberToGreenLight;
        _delayGreenToAmberLight = _trafficLighData._delayGreenToAmberLight;
        _delayAmberToRedLight = _trafficLighData._delayAmberToRedLight;
        _delayRedToAmberLight = _trafficLighData._delayRedToAmberLight;
      
    }

    private void Start()
    {
        //I used from inspector, not the GameObject.FindGameObjectsWithTag() method 
        //because there can be many intersections on one scene but not all of them should work at the same time
        DeactivateAllLights();
        //Select green state to first traffic light 
        trafficLights[_currentTrafficLight].SwitchLight(TrafficLightState.Green);
        StartCoroutine(FromGreenToRedTrafficLight());

    }

    private void DeactivateAllLights()
    {
        foreach (var trafficLight in trafficLights)
        {
            trafficLight.SwitchLight(TrafficLightState.Red);
        }
    }

    IEnumerator  FromGreenToRedTrafficLight()
    {
        yield return new WaitForSeconds(_delayGreenToAmberLight);
        trafficLights[_currentTrafficLight].SwitchLight(TrafficLightState.Amber);
        yield return new WaitForSeconds(_delayAmberToRedLight);
        trafficLights[_currentTrafficLight].SwitchLight(TrafficLightState.Red);
        trafficLights[_currentTrafficLight].ChangePlayerText(false);
        _currentTrafficLight++;
        if (_currentTrafficLight >= trafficLights.Count)
            _currentTrafficLight = 0;
        StartCoroutine(FromRedToGreenTrafficLight());
    }

    IEnumerator FromRedToGreenTrafficLight()
    {
        yield return new WaitForSeconds(_delayRedToAmberLight);
        trafficLights[_currentTrafficLight].ChangePlayerText(true);
        trafficLights[_currentTrafficLight].SwitchLight(TrafficLightState.Amber);
        yield return new WaitForSeconds(_delayAmberToGreenLight);
        trafficLights[_currentTrafficLight].SwitchLight(TrafficLightState.Green);
        StartCoroutine(FromGreenToRedTrafficLight());
    }

  
    
}
