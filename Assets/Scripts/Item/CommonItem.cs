using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
[RequireComponent(typeof(BonusHandler))]
public class CommonItem : Item
{
    [SerializeField] private List<Sprite> _sprites;

    private HingeJoint2D _joint;

    private void Start()
    {
        if (Renderer.sprite == null)
            Renderer.sprite = _sprites[Random.Range(0, _sprites.Count)];

        SetJoint();
        
        _type = ItemType.Common;
        Collider.isTrigger = false;
    }

    private void SetJoint()
    {
        if (TryGetComponent(out _joint) == false)
            gameObject.AddComponent<HingeJoint2D>();

        _joint = GetComponent<HingeJoint2D>();
        _joint.useLimits = true;
        _joint.autoConfigureConnectedAnchor = true;
        _joint.enableCollision = true;
        _joint.limits = new()
        {
            min = -180,
            max = 180
        };
    }
}