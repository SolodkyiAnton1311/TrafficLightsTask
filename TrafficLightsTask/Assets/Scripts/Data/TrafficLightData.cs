using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TrafficLightData",menuName = "Object/TrafficLight")]
public class TrafficLightData : ScriptableObject
{
    
     public float _delayGreenToAmberLight;
     public float _delayRedToAmberLight;
     public float _delayAmberToGreenLight;
     public float _delayAmberToRedLight;
 
 

}
