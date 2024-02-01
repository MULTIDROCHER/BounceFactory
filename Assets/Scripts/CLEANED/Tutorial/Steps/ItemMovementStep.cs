using System.Collections.Generic;

namespace BounceFactory
{
    public class ItemMovementStep : TutorialStep
    {
        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() {
{ "ru", "зажми и двигай предмет,\nчтобы переместить его" },
{ "en", "pinch and move the object\nto move it" },
{ "tr", "Nesneyi hareket ettirmek için\nsıkıştırın ve hareket ettirin" },
    };
        }

        private List<ItemMover> _itemMovers;

        private ItemHolder _holder => TutorialManager.Instance.ItemHolder;

        public override void Enter()
        {
            foreach (var item in _holder.Contents)
                _itemMovers.Add(item.GetComponent<ItemMover>());

            foreach (var mover in _itemMovers)
                mover.Performed += OnPerformed;

            OnUnneedMask(CommonMessages()[Language]);
        }

        public override void Exit()
        {
            foreach (var mover in _itemMovers)
                mover.Performed -= OnPerformed;
        }
    }
}