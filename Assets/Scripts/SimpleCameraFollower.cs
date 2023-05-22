using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followedObject;
    [SerializeField] private bool isFollowing;
    void LateUpdate()
    {
        if(!isFollowing) return;
        if(followedObject == null)
        {
            Debug.LogError("no object set to follow in " + this.name);
            isFollowing = false;
            return;
        }
        transform.position = new Vector3(followedObject.position.x, followedObject.position.y, transform.position.z);
    }
}
