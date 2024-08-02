using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AttachObject : MonoBehaviour
{
    public GameObject attachObject,previousParentObject, newParentObject;

    UnityEngine.Vector3 defaultPosition;
    public void AttachPickUp()
    {
        defaultPosition = attachObject.transform.localPosition;
        attachObject.transform.SetParent(newParentObject.transform);
        attachObject.transform.localPosition=UnityEngine.Vector3.zero;
    }

    public  void ReturnPickUp()
    {
        attachObject.transform.SetParent(previousParentObject.transform);
        attachObject.transform.localPosition=defaultPosition;
        
    }
}
