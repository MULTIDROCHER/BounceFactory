using System.Linq;
using UnityEngine;

public class Step2 : TutorialStep
{
    private const string Message = "отлично, теперь купи пару шаров";

    private BallSeller _seller;
    private PriceDisplay _target;

    public override void Enter()
    {
        _seller = Object.FindObjectOfType<BallSeller>();
        _target = Object.FindObjectsOfType<PriceDisplay>().FirstOrDefault(display => display.Seller == _seller);
        _seller.Performed += OnPerformed;
        OnNeedMask(Message, _target.transform);
    }

    public override void Exit() => _seller.Performed -= OnPerformed;
}