// ********************************************************************** //
//
//   Copyright (c) 2023 Rimuru Tempest aka RimuruDev. All rights reserved.
//   This code is licensed under the MIT license (see LICENSE for details)
//   Contact me: rimuru.dev@gmail.com
//
// ********************************************************************** //

using System;
using System.Collections.Generic;
using RimuruDev.Codebase.HeroStateMachine.Base;
using RimuruDev.Codebase.HeroStateMachine.States;
using UnityEngine;

namespace RimuruDev.Codebase.HeroStateMachine.View
{
    public sealed class HeroStateMachine : MonoBehaviour
    {
        [Header("Hero Input Settings")]
        [SerializeField] private float walkSpeed = 10f;
        [SerializeField] private float runSpeed = 20f;

        private readonly StateMachine _stateMachine = new();

        public void Awake()
        {
            InitializeHeroStateMachine();

            _stateMachine.Awake();
        }

        private void Start() =>
            _stateMachine.Start();

        private void FixedUpdate() =>
            _stateMachine.FixedUpdate();

        private void Update() =>
            _stateMachine.Update();

        private void LateUpdate() =>
            _stateMachine.LateUpdate();

        private void OnDestroy() =>
            _stateMachine.FullCleanup();

        private void InitializeHeroStateMachine()
        {
            var hero = gameObject;

            _stateMachine.AddStates(new Dictionary<Type, State>
            {
                [typeof(HeroIdleState)] = new HeroIdleState(_stateMachine),
                [typeof(HeroRunState)] = new HeroRunState(_stateMachine, hero, runSpeed),
                [typeof(HeroWalkState)] = new HeroWalkState(_stateMachine, hero, walkSpeed),
            });

            _stateMachine.SwitchState<HeroIdleState>();
        }
    }
}