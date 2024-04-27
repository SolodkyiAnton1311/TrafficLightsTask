using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadTrigger : MonoBehaviour
{
    [SerializeField] private TrafficLight trafficLightManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          other.GetComponent<PlayerUIManager>().trafficLightIndicator.gameObject.SetActive(true);
          trafficLightManager._carList.Add(other.GetComponent<PlayerUIManager>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerUIManager>().trafficLightIndicator.gameObject.SetActive(false);
            trafficLightManager._carList.Remove(other.GetComponent<PlayerUIManager>());
        }
    }
}
