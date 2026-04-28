using System;
using UnityEngine;

public class PlayerRig : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;
    [SerializeField] private CapsuleCollider _bodyCollider;
    
    [SerializeField] private ConfigurableJoint _headJoint;
    [SerializeField] private ConfigurableJoint _leftHandJoint;
    [SerializeField] private ConfigurableJoint _rightHandJoint;
    [SerializeField] private Vector2 _bodySizeConstraints = new(0.5f, 2f);

    private void FixedUpdate()
    {
        _bodyCollider.height = Math.Clamp(_head.localPosition.y, _bodySizeConstraints.x, _bodySizeConstraints.y);
        _bodyCollider.center = new Vector3(_head.localPosition.x, _bodyCollider.height * 0.5f, _head.localPosition.z);
        
        _leftHandJoint.targetPosition = _leftHand.localPosition;
        _leftHandJoint.targetRotation = _leftHand.localRotation;
        _rightHandJoint.targetPosition = _rightHand.localPosition;
        _rightHandJoint.targetRotation = _rightHand.localRotation;
        _headJoint.targetPosition = _head.localPosition;
    }
}