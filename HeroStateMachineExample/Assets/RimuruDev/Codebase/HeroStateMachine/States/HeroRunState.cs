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
    public sealed class HeroRunState : HeroMovementState
    {
        public HeroRunState(StateMachine stateMachine, GameObject hero, float speed) : base(stateMachine, hero, speed)
        {
        }

        public override void Update()
        {
            Debug.Log("[Enter: Hero Override Run State]");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
                StateMachine.SwitchState<HeroIdleState>();

            if (Input.GetKeyUp(KeyCode.LeftShift))
                StateMachine.SwitchState<HeroWalkState>();

            Move(inputDirection);
        }
    }
}