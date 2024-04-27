using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrafficLight
{

    public void SwitchLight(TrafficLightState state);
    public void ChangePlayerText(bool canDrive);

}