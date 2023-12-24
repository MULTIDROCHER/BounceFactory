using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class TutorialManager : MonoBehaviour
{
    private Dictionary<string, string> _messages = new(){
{ "ru", "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)" },
{ "en", "Yay, now you know the basic mechanics! Enjoy the game! :)" },
{ "tr", "Yaşasın, artık temel mekanikleri biliyorsunuz! Oyunun tadını çıkarın! :)" },
    };

    public static TutorialManager Instance;

    [SerializeField] private GameObject _overlay;
    [SerializeField] private GameObject _mask;
    [SerializeField] private TMP_Text _text;

    private readonly float _delay = .5f;

    private TutorialStateMachine _stateMachine;
    private WaitForSeconds _wait;

    public GameObject Mask => _mask;
    public TMP_Text Text => _text;

    private void Awake()
    {
        if (GameManager.Instance.IsTrained)
            Destroy(gameObject);

        Instance = this;
    }

    private void Start()
    {
        _wait = new(_delay);

        _stateMachine = new();
        Step0 step = new();

        _stateMachine.Initialize(step);
        step.Completed += Step1;
    }

    public void SetOverlay(bool enabled) => _overlay.SetActive(enabled);

    private void Step1()
    {
        Step1 step = new();
        ExecuteStep(step, Step2);
    }

    private void Step2()
    {
        Step2 step = new();
        ExecuteStep(step, Step3);
    }

    private void Step3()
    {
        Step3 step = new();
        ExecuteStep(step, Step4);
    }

    private void Step4()
    {
        Step4 step = new();
        ExecuteStep(step, Step5);
    }

    private void Step5()
    {
        Step5 step = new();
        ExecuteStep(step, Step6);
    }

    private void Step6()
    {
        Step6 step = new();
        ExecuteStep(step, Step7);
    }

    private void Step7()
    {
        Step7 step = new();
        ExecuteStep(step, () => StartCoroutine(End()));
    }

    private IEnumerator End()
    {
        int delay = 2;

        _text.text = _messages[YandexGame.lang];
        yield return new WaitForSeconds(delay);
        Skip();
    }

    public void Skip()
    {
        _stateMachine.CurrentState.Exit();
        GameManager.Instance.TutorialPassed();
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void ExecuteStep(TutorialStep step, Action nextStep)
    {
        StartCoroutine(ChangeStep(step));
        step.Completed += nextStep;
    }

    private IEnumerator ChangeStep(TutorialStep step)
    {
        yield return _wait;
        _stateMachine.ChangeState(step);
        StopAllCoroutines();
    }
}