public class TutorialStateMachine
{
    public TutorialStep CurrentState { get; private set; }

    public void Initialize(TutorialStep startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(TutorialStep newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}