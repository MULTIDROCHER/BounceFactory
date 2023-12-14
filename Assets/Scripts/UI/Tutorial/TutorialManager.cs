using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [SerializeField] private GameObject _overlay;
    [SerializeField] private GameObject _mask;
    [SerializeField] private TMP_Text _text;
    private TutorialStateMachine _stateMachine;

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
        _stateMachine = new();
        Step0 step = new(_text, _mask);

        _stateMachine.Initialize(step);
        step.Completed += Step2;
    }

    public void SetOverlay(bool enabled) => _overlay.SetActive(enabled);

    private void Step2()
    {
        Step1 step = new(_text, _mask);
        _stateMachine.ChangeState(step);
        step.Completed += End;
    }

    private void End()
    {
        _stateMachine.CurrentState.Exit();
    }
}
