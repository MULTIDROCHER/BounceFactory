using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private const string EndMessage = "Ура, теперь ты знаешь основные\nмеханики! Приятной игры! :)";

    public static TutorialManager Instance;

    [SerializeField] private GameObject _overlay;
    [SerializeField] private GameObject _mask;
    [SerializeField] private TMP_Text _text;

    private TutorialStateMachine _stateMachine;
    private WaitForSeconds _wait;
    private float _delay = .5f;

    private void Awake()
    {
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
        Step0 step = new(_text, _mask);

        _stateMachine.Initialize(step);
        step.Completed += Step1;
    }

    public void SetOverlay(bool enabled) => _overlay.SetActive(enabled);

    private void Step1()
    {
        Step1 step = new(_text, _mask);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step2;
    }

    private void Step2()
    {
        Step2 step = new(_text, _mask);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step3;
    }

    private void Step3()
    {
        Step3 step = new(_text, _mask);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step4;
    }

    private void Step4()
    {
        Step4 step = new(_text, _mask);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step5;
    }

    private void Step5()
    {
        Step5 step = new(_text);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step6;
    }

    private void Step6()
    {
        Step6 step = new(_text);
        StartCoroutine(ChangeStep(step));
        step.Completed += Step7;
    }

    private void Step7()
    {
        Step7 step = new(_text);
        StartCoroutine(ChangeStep(step));
        step.Completed += End;
    }

    private void End()
    {
        _stateMachine.CurrentState.Exit();
        _text.text = EndMessage;
        StopAllCoroutines();
        Destroy(gameObject, 2);
    }

    private IEnumerator ChangeStep(TutorialStep step)
    {
        yield return _wait;
        _stateMachine.ChangeState(step);
        StopAllCoroutines();
    }
}
