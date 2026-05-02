using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Systems.Player
{
    public class PlayerGrab : MonoBehaviour
    {
        [SerializeField] private XRBaseInteractor _interactor;
        private FixedJoint _joint;

        private void HandleSelectEntered(SelectEnterEventArgs args)
        {
            var interactable = args.interactableObject;
            if (interactable == null)
            {
                return;
            }
            var body = interactable.transform.GetComponent<Rigidbody>();
            if (!body)
            {
                return;
            }

            _joint = gameObject.AddComponent<FixedJoint>();
            _joint.autoConfigureConnectedAnchor = false;
            _joint.connectedBody = body;
            _joint.connectedAnchor = transform.InverseTransformPoint(interactable.transform.position);
            Debug.Log($"Grabbing {interactable.transform.gameObject.name}");
        }

        private void HandleSelectExited(SelectExitEventArgs args)
        {
            var interactable = args.interactableObject;
            if (_joint)
            {
                Destroy(_joint);
            }
            Debug.Log($"Releasing {interactable.transform.gameObject.name}");
        }
        
        private void Awake()
        {
            if (!_interactor)
            {
                Debug.LogWarning("PlayerGrab Interactor missing");
                return;
            }
            
            _interactor.selectEntered.AddListener(HandleSelectEntered);
            _interactor.selectExited.AddListener(HandleSelectExited);
        }
        
        private void OnDestroy()
        {
            _interactor.selectEntered.RemoveListener(HandleSelectEntered);
            _interactor.selectExited.RemoveListener(HandleSelectExited);
        }
    }
}