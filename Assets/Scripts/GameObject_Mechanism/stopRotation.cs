using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopRotation : MonoBehaviour
{
    private Transform parentTransform;

    private void Start()
    {
        // Get a reference to the parent's Transform.
        parentTransform = transform.parent;
    }

    private void LateUpdate()
    {
        // Counteract the parent's rotation by applying the opposite rotation to the child.
        transform.rotation = Quaternion.Inverse(parentTransform.rotation);
    }
}
