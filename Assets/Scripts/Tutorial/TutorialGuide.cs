using System.Collections;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;
using BounceFactory.Logic;
using BounceFactory.Playground.FlipperSystem;
using BounceFactory.Playground.Storage;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.Tutorial.Steps;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public class TutorialGuide : MonoBehaviour
    {
        private readonly float _delay = 2;
        private readonly TutorialStateMachine _stateMachine = new ();
        private readonly Dictionary<string, string> _messages = new ()
        {
            { "ru", "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)" },
            { "en", "Yay, now you know the basic \nmechanics! Enjoy the game! :)" },
            { "tr", "Yaşasın, artık temel mekanikleri \nbiliyorsunuz! Oyunun tadını çıkarın! :)" },
        };

        private readonly List<TutorialStep> _steps = new () { };

        [SerializeField] private GameObject _overlay;
        [SerializeField] private GameObject _mask;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private BallMerger _merger;
        [SerializeField] private ItemHolder _itemHolder;
        [SerializeField] private FlipperActivatorsContainer _activatorsContainer;
        [SerializeField] private PriceView<Ball> _ballPrice;
        [SerializeField] private PriceView<Item> _itemPrice;

        private int _currentStepIndex = 0;
        private WaitForSeconds _wait;

        public GameObject Mask => _mask;

        public TMP_Text Text => _text;

        public BallMerger Merger => _merger;

        public ItemHolder ItemHolder => _itemHolder;

        public FlipperActivator[] Activators => _activatorsContainer.Activators;

        private void Awake()
        {
            if (YandexGame.savesData.IsTrained)
                Destroy(gameObject);

            _wait = new WaitForSeconds(_delay);
        }

        private void Start()
        {
            _steps.Add(new RightFlipperStep(this, KeyCode.X));
            _steps.Add(new LeftFlipperStep(this, KeyCode.Z));
            _steps.Add(new BallsPurchaseStep(this, _ballPrice));
            _steps.Add(new BallsMergeStep(this));
            _steps.Add(new FirstItemPurchaseStep(this, _itemPrice));
            _steps.Add(new ItemMovementStep(this));
            _steps.Add(new SecondItemPurchaseStep(this, _itemPrice));
            _steps.Add(new ItemsMergeStep(this));

            _stateMachine.Initialize(_steps[_currentStepIndex]);
            _steps[_currentStepIndex].Completed += NextStep;
        }

        public void Skip()
        {
            _stateMachine.CurrentState.Exit();
            YandexGame.savesData.IsTrained = true;
            StopAllCoroutines();
            Destroy(gameObject);
        }

        public void EnableOverlay() => _overlay.SetActive(true);

        public void DisableOverlay() => _overlay.SetActive(false);

        private void NextStep()
        {
            _steps[_currentStepIndex].Completed -= NextStep;
            _currentStepIndex++;

            if (_currentStepIndex >= _steps.Count)
            {
                StartCoroutine(End());
            }
            else
            {
                _stateMachine.ChangeState(_steps[_currentStepIndex]);
                _steps[_currentStepIndex].Completed += NextStep;
            }
        }

        private IEnumerator End()
        {
            _text.text = _messages[YandexGame.lang];
            yield return _wait;
            Skip();
        }
    }
}