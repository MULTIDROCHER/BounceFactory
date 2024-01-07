using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Step2 : TutorialStep
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "отлично, теперь купи пару шаров" },
{ "en", "Great, now buy a couple balls" },
{ "tr", "Harika, şimdi birkaç balon al" },
    };
    private BallSeller _seller;
    private PriceDisplay _target;

    public override void Enter()
    {
        _seller = Object.FindObjectOfType<BallSeller>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller == _seller);
        _seller.Performed += OnPerformed;
        
        OnNeedMask(_messages[Language], _target.transform.parent.parent);
    }

    public override void Exit() => _seller.Performed -= OnPerformed;
}