using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyAnim : MonoBehaviour
{
    public Transform target;
    private ConfigurableJoint joint;

    private Quaternion startingRotation;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startingRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        joint.SetTargetRotationLocal(target.localRotation, startingRotation);
    }
}
