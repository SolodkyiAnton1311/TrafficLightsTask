using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour, ITrafficLight
{
    [SerializeField] private GameObject _greenLightObject;
    [SerializeField] private GameObject _amberLightObject;
    [SerializeField] private GameObject _redLightObject;
     public List<PlayerUIManager> _carList;
   

    public void SwitchLight(TrafficLightState state)
    {
        DeactivateLight();
        switch (state)
        {
            case TrafficLightState.Green:
                _greenLightObject.SetActive(true);

                break;
            case TrafficLightState.Amber:

                _amberLightObject.SetActive(true);
                break;
            case TrafficLightState.Red:

                _redLightObject.SetActive(true);
                break;
        }
    }

    private void DeactivateLight()
    {
        _greenLightObject.SetActive(false);
        _amberLightObject.SetActive(false);
        _redLightObject.SetActive(false);
    }
    
    public void ChangePlayerText(bool canDrive)
    {
        foreach (var player in _carList)
        {
            if (canDrive)
            {
                player.trafficLightIndicator.text = "Can Drive";
                return;
            }
            player.trafficLightIndicator.text = "Can't Drive";
        }
        
    }


}

public enum TrafficLightState
{
    Green,
    Amber,
    Red
}