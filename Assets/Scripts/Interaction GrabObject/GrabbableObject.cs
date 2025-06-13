using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabbableObject : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable.MovementType _movementType;

    private XRGrabInteractable grabInteractable;
    void Start()
    {
        //XRGrabInteractable 스크립트 어태치
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            gameObject.AddComponent<XRGrabInteractable>();
        }
        grabInteractable.movementType = _movementType;

        // 이벤트 등록
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("오브젝트가 집어졌습니다!");
        // 집었을 때 효과 추가하면 좋을 듯(소리, 진동 등)
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("오브젝트가 놓여졌습니다!");
        // 놓았을 때 효과 추가 
    }
}

