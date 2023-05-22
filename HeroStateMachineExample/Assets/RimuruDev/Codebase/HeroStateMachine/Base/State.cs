// ********************************************************************** //
//
//   Copyright (c) 2023 Rimuru Tempest aka RimuruDev. All rights reserved.
//   This code is licensed under the MIT license (see LICENSE for details)
//   Contact me: rimuru.dev@gmail.com
//
// ********************************************************************** //

using System;

namespace RimuruDev.Codebase.HeroStateMachine.Base
{
    public abstract class State : IDisposable
    {
        protected readonly StateMachine StateMachine;

        protected State(StateMachine stateMachine) =>
            StateMachine = stateMachine;

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Awake()
        {
        }

        public virtual void Start()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void LateUpdate()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}