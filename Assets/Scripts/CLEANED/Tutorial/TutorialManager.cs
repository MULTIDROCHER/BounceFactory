using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [SerializeField] private GameObject _overlay;
    [SerializeField] private GameObject _mask;
    [SerializeField] private TMP_Text _text;

    private readonly float _delay = 2;
    private readonly TutorialStateMachine _stateMachine = new();
    private readonly Dictionary<string, string> _messages = new(){
        { "ru", "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)" },
        { "en", "Yay, now you know the basic \nmechanics! Enjoy the game! :)" },
        { "tr", "Yaşasın, artık temel mekanikleri \nbiliyorsunuz! Oyunun tadını çıkarın! :)" }, 
    };
    private readonly List<TutorialStep> _steps = new() {
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

    public GameObject Mask => _mask;
    public TMP_Text Text => _text;

    private void Awake()
    {
        Instance = this;

        if (YandexGame.savesData.IsTrained)
            Destroy(gameObject);
    }

    private void Start()
    {
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

    public void SetOverlay(bool enabled) => _overlay.SetActive(enabled);

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
        yield return new WaitForSeconds(_delay);
        Skip();
    }
}