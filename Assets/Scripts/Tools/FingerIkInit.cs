using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(ChainIKConstraint))]
public class FingerIkInit : MonoBehaviour
{
    [SerializeField]
    private Transform _fingerRoot;
    
    [Button]
    private void InitConstraint()
    {
        if (_fingerRoot == null)
        {
            Debug.LogWarning("ChainIKConstraint.InitConstraint: _fingerRoot is null.");
            return;
        }
        
        Transform source = new GameObject("Source").transform;
        source.parent = transform;
        source.localPosition = Vector3.zero;
        source.localRotation = Quaternion.identity;
        
        ChainIKConstraint fingerIKConstraint = GetComponentInChildren<ChainIKConstraint>();
        if (fingerIKConstraint == null)
        {
            return;
        }

        fingerIKConstraint.data.root = _fingerRoot;
        
        Transform tip;
        Transform tipParent = _fingerRoot;
        while (tipParent.childCount > 0)
        {
            tipParent = tipParent.GetChild(0);
        }
        tip = tipParent;
        fingerIKConstraint.data.tip = tip;

        fingerIKConstraint.data.target = source;
    }
}
