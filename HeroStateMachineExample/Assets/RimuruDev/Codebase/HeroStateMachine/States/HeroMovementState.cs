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
    public abstract class HeroMovementState : State
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private readonly GameObject _hero;
        private readonly float _speed;

        protected HeroMovementState(StateMachine stateMachine, GameObject hero, float speed) : base(stateMachine)
        {
            _hero = hero;
            _speed = speed;
        }

        public override void Enter() =>
            Debug.Log("[Enter: Hero Movement State]");

        public override void Exit() =>
            Debug.Log("[Exit: Hero Movement State]");

        public override void Update()
        {
            Debug.Log("[Update: Hero Movement State]");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
                StateMachine.SwitchState<HeroIdleState>();

            Move(inputDirection);
        }

        protected Vector2 ReadInput()
        {
            var inputHorizontal = Input.GetAxis(HorizontalAxis);
            var inputVertical = Input.GetAxis(VerticalAxis);
            var inputDirection = new Vector2(inputHorizontal, inputVertical);

            return inputDirection;
        }

        protected void Move(Vector2 inputDirection)
        {
            var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
            var normalizeDirection = direction * (_speed * Time.deltaTime);

            _hero.transform.position += normalizeDirection;
        }
    }
}