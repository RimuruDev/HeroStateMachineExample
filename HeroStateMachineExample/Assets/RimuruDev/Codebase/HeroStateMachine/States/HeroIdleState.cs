// ********************************************************************** //
//
//   Copyright (c) 2023 Rimuru Tempest aka RimuruDev. All rights reserved.
//   This code is licensed under the MIT license (see LICENSE for details)
//   Contact me: rimuru.dev@gmail.com
//
// ********************************************************************** //

using RimuruDev.Codebase.HeroStateMachine.Base;
using UnityEngine;

namespace RimuruDev.Codebase.HeroStateMachine.States
{
    public class HeroIdleState : State
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public HeroIdleState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter() =>
            Debug.Log("[Enter: Hero Idle State]");

        public override void Exit() =>
            Debug.Log("[Exit: Hero Idle State]");

        public override void Update()
        {
            Debug.Log("[Update: Hero Idle State]");

            if (CanHeroMovement())
                StateMachine.SwitchState<HeroWalkState>();
        }

        private static bool CanHeroMovement() =>
            Input.GetAxis(HorizontalAxis) != 0f || Input.GetAxis(VerticalAxis) != 0f;
    }
}