using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.Player
{
    public class PlayerGrab : MonoBehaviour
    {
        [SerializeField] private InputActionReference _grabAction;
        [SerializeField] private Rigidbody _interactableBody;
        [SerializeField] private string _grabbedLayerName;
        [SerializeField] private string _releasedLayerName;
        
        private FixedJoint _joint;
        private int _grabbedLayer;
        private int _releasedLayer;

        private void OnGrab(InputAction.CallbackContext context)
        {
            if (_interactableBody == null)
            {
                return;
            }
            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.connectedBody = _interactableBody;
            _interactableBody.gameObject.layer = _grabbedLayer;
        }

        private void OnRelease(InputAction.CallbackContext context)
        {
            if (_joint)
            {
                _joint.connectedBody.gameObject.layer = _releasedLayer;
                Destroy(_joint);
            }
        }

        private void SubscribeGrabAction()
        {
            if (!_grabAction)
            {
                Debug.LogWarning("PlayerGrab Grab Action missing");
                return;
            }
            
            _grabAction.action.performed += OnGrab;
            _grabAction.action.canceled += OnRelease;
        }

        private void UnsubscribeGrabAction()
        {
            if (!_grabAction)
            {
                return;
            }
            _grabAction.action.performed -= OnGrab;
            _grabAction.action.canceled -= OnRelease;
        }
        
        private void InitGrabbableLayers()
        {
            _grabbedLayer =  LayerMask.NameToLayer(_grabbedLayerName);
            _releasedLayer =  LayerMask.NameToLayer(_releasedLayerName);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var body = other.attachedRigidbody;
            if (!body)
            {
                return;
            }
            _interactableBody = body;
        }

        private void OnTriggerExit(Collider other)
        {
            var body = other.attachedRigidbody;
            if (_interactableBody == body)
            {
                _interactableBody = null;
            }
        }

        private void Awake()
        {
            SubscribeGrabAction();
            InitGrabbableLayers();
        }
        
        private void OnDestroy()
        {
            UnsubscribeGrabAction();
        }
    }
}