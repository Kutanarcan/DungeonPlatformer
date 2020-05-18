using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState currentState;

    Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    List<Transition> currentTransitions = new List<Transition>();
    List<Transition> anyTransitions = new List<Transition>();

    static List<Transition> EmptyTransitions = new List<Transition>(capacity: 0);

    public void Tick()
    {
        Transition transition = GetTransition();
        if (transition != null)
            SetState(transition.To);

        currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if (state == currentState)
            return;

        currentState?.OnStateExit();
        currentState = state;

        transitions.TryGetValue(currentState.GetType(), out currentTransitions);

        if (currentTransitions == null)
            currentTransitions = EmptyTransitions;

        currentState.OnStateEnter();
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if (transitions.TryGetValue(from.GetType(), out List<Transition> outTransitions) == false)
        {
            outTransitions = new List<Transition>();
            transitions[from.GetType()] = outTransitions;
        }

        outTransitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        anyTransitions.Add(new Transition(state, predicate));
    }

    class Transition
    {
        public Func<bool> Condition { get; }

        public IState To { get; }

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    Transition GetTransition()
    {
        foreach (var transition in anyTransitions)
        {
            if (transition.Condition())
                return transition;
        }

        foreach (var transition in currentTransitions)
        {
            if (transition.Condition())
                return transition;
        }

        return null;
    }
}
