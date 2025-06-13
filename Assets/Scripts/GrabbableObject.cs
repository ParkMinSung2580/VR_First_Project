using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabbableObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        //XRGrabInteractable ��ũ��Ʈ ����ġ
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        if(grabInteractable == null)
        {
            gameObject.AddComponent<XRGrabInteractable>();
        }
        Debug.Log(grabInteractable.movementType);
        grabInteractable.movementType = XRBaseInteractable.MovementType.VelocityTracking;

        // �̺�Ʈ ���
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("������Ʈ�� ���������ϴ�!");
        // ������ �� ȿ�� �߰��ϸ� ���� ��(�Ҹ�, ���� ��)
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("������Ʈ�� ���������ϴ�!");
        // ������ �� ȿ�� �߰� 
    }
}

