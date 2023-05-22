// ********************************************************************** //
//
//   Copyright (c) 2023 Rimuru Tempest aka RimuruDev. All rights reserved.
//   This code is licensed under the MIT license (see LICENSE for details)
//   Contact me: rimuru.dev@gmail.com
//
// ********************************************************************** //

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RimuruDev.Codebase.HeroStateMachine.Base
{
    public class StateMachine
    {
        public event Action<State> OnSwitchState;

        private State _currentState;
        private readonly Dictionary<Type, State> _states;

        public StateMachine() =>
            _states = new Dictionary<Type, State>();

        public StateMachine(Dictionary<Type, State> states) =>
            _states = states ?? throw new ArgumentNullException();

        ~StateMachine() =>
            FullCleanup();

        public void AddState(State state)
        {
            if (state == null)
                throw new NullReferenceException();

            if (_states.ContainsKey(state.GetType()))
                throw new NullReferenceException();

            _states.Add(state.GetType(), state);
        }

        public void AddStates(Dictionary<Type, State> states)
        {
            if (states == null)
                throw new NullReferenceException();

            foreach (var state in states.Where(state => state.Key != null || state.Value != null))
                _states.Add(state.Key, state.Value);
        }

        public void SwitchState<TState>() where TState : State
        {
            var type = typeof(TState);

            if (type == null)
                throw new NullReferenceException($"{nameof(type)}");

            if (_currentState != null && _currentState.GetType() == type)
                return;

            if (!_states.TryGetValue(type, out var newState))
            {
                Debug.LogWarning("State not found!");
                return;
            }

            _currentState?.Exit();

            _currentState = newState;

            _currentState?.Enter();

            OnSwitchState?.Invoke(newState);
        }

        public void Awake() =>
            _currentState?.Awake();

        public void Start() =>
            _currentState?.Start();

        public void Update() =>
            _currentState?.Update();

        public void LateUpdate() =>
            _currentState?.LateUpdate();

        public void FixedUpdate() =>
            _currentState?.FixedUpdate();

        public void DisposeState() =>
            _currentState?.Dispose();

        public void FullCleanup()
        {
            if (_states == null)
                return;

            foreach (var state in _states.Where(state => state.Value != null))
                state.Value.Dispose();

            _states.Clear();

            _currentState = null;
        }
    }
}