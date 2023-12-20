using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private const string EndMessage = "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)";

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

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
        ExecuteStep(step, End);
    }

    private void End()
    {
        _stateMachine.CurrentState.Exit();
        _text.text = EndMessage;
        StopAllCoroutines();
        GameManager.Instance.TutorialPassed();
        Destroy(gameObject, 2);
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