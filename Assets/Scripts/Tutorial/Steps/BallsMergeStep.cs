using System.Collections.Generic;
using BounceFactory.Logic;

namespace BounceFactory.Tutorial.Steps
{
    public class BallsMergeStep : TutorialStep
    {
        public BallsMergeStep(TutorialGuide guide) : base(guide)
        {
        }

        private BallMerger Merger => Guide.Merger;

        public override void Enter()
        {
            base.Enter();
            Merger.Performed += OnPerformed;
            OnNeedMask(CommonMessages()[Language], Merger.Button.transform);
        }

        public override void Exit() => Merger.Performed -= OnPerformed;

        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() 
        {
            { "ru", "когда у тебя достаточно шаров одного\nуровня, ты можешь их объединять" },
            { "en", "when you have enough balls of the\nsame level, you can merge them" },
            { "tr", "Aynı seviyede yeterince topunuz \nolduğunda,onları birleştirebilirsiniz" },
        };
        }
    }
}