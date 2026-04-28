using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Systems.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private XRBaseInteractor _leftHand;
        [SerializeField] private XRBaseInteractor _rightHand;

        [SerializeField] private string _grabbedLayerName;
        [SerializeField] private string _releasedLayerName;
    
        private int _grabbedLayer;
        private int _releasedLayer;
    

        private void HandleOnGrab(SelectEnterEventArgs args)
        {
            args.interactableObject.transform.gameObject.layer = _grabbedLayer;
        }

        private void HandleOnRelease(SelectExitEventArgs args)
        {
            args.interactableObject.transform.gameObject.layer = _releasedLayer;
        }

        private void SubscribeInteractors()
        {
            _leftHand.selectEntered.AddListener(HandleOnGrab);
            _leftHand.selectExited.AddListener(HandleOnRelease);
            _rightHand.selectEntered.AddListener(HandleOnGrab);
            _rightHand.selectExited.AddListener(HandleOnRelease);
        }

        private void InitLayers()
        {
            _grabbedLayer = LayerMask.NameToLayer(_grabbedLayerName);
            _releasedLayer = LayerMask.NameToLayer(_releasedLayerName);
        }
    
        private void Awake()
        {
            InitLayers();
            SubscribeInteractors();
        }
    }
}
