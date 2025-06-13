using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State; //XRInteractableAffordanceStateProvider ����ϱ� ���� ���� �����̽�
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Affordance : MonoBehaviour
{
    private XRInteractableAffordanceStateProvider affordanceProvider;
    void Start()
    {
        affordanceProvider = GetComponent<XRInteractableAffordanceStateProvider>();

        if (affordanceProvider == null)
        {
            gameObject.AddComponent<XRInteractableAffordanceStateProvider>();
        }
    }

    void Update()
    {
        
    }
}
