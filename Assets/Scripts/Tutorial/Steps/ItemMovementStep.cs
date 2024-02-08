using System.Collections.Generic;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Playground.Storage.Holder;

namespace BounceFactory.Tutorial.Steps
{
    public class ItemMovementStep : TutorialStep
    {
        private readonly List<ItemMover> _movers = new ();

        public ItemMovementStep(TutorialGuide guide) : base(guide)
        {
        }

        private ItemHolder Holder => Guide.ItemHolder;

        public override void Enter()
        {
            base.Enter();
            Holder.UpdateContent();

            foreach (var item in Holder.Contents)
                _movers.Add(item.GetComponent<ItemMover>());

            foreach (var mover in _movers)
                mover.Performed += OnPerformed;

            OnUnneedMask(CommonMessages()[Language]);
        }

        public override void Exit()
        {
            foreach (var mover in _movers)
                mover.Performed -= OnPerformed;
        }

        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() 
        {
            { "ru", "зажми и двигай предмет,\nчтобы переместить его" },
            { "en", "pinch and move the object\nto move it" },
            { "tr", "Nesneyi hareket ettirmek için\nsıkıştırın ve hareket ettirin" },
        };
        }
    }
}