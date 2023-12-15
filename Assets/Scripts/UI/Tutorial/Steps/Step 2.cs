using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Step2 : TutorialStep
{
    private const string Message = "отлично, теперь купи пару шаров";

    private GameObject _mask;
    private BallSeller _seller;
    private PriceDisplay _target;

    public Step2(TMP_Text text, GameObject mask) : base(text)
    {
        _mask = mask;
    }

    public override void Enter()
    {
        _seller = Object.FindObjectOfType<BallSeller>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller == _seller);
        OnNeedMask();
    }

    protected override void OnNeedMask()
    {
        base.OnNeedMask();
        ChangeText(Message);
        _seller.Performed += OnPerformed;
        _mask.transform.position = GetMaskPosition(_target.transform);
    }

    public override void Exit()
    {
        base.Exit();
        _seller.Performed -= OnPerformed;
    }
}