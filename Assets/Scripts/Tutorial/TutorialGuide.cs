using BounceFactory.Logic;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.Tutorial.Steps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.Tutorial
{
    public class TutorialGuide : MonoBehaviour
    {
        public static TutorialGuide Instance;

        [SerializeField] private GameObject _overlay;
        [SerializeField] private GameObject _mask;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private BallMerger _merger;
        [SerializeField] private ItemHolder _itemHolder;

        private readonly float _delay = 2;
        private readonly TutorialStateMachine _stateMachine = new ();
        private readonly Dictionary<string, string> _messages = new (){
        { "ru", "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)" },
        { "en", "Yay, now you know the basic \nmechanics! Enjoy the game! :)" },
        { "tr", "Yaşasın, artık temel mekanikleri \nbiliyorsunuz! Oyunun tadını çıkarın! :)" },
    };
        private readonly List<TutorialStep> _steps = new () {
        new RightFlipperStep(KeyCode.X),
        new LeftFlipperStep(KeyCode.Z),
        new BallsPurchaseStep(),
        new BallsMergeStep(),
        new FirstItemPurchaseStep(),
        new ItemMovementStep(),
        new SecondItemPurchaseStep(),
        new ItemsMergeStep()
    };

        private int _currentStepIndex = 0;
        private WaitForSeconds _wait;

        public GameObject Mask => _mask;
        public TMP_Text Text => _text;
        public BallMerger Merger => _merger;
        public ItemHolder ItemHolder => _itemHolder;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
                Instance = this;

            if (YandexGame.savesData.IsTrained)
                Destroy(gameObject);
        }

        private void Start()
        {
            _wait = new WaitForSeconds(_delay);

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