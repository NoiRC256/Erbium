﻿using System;
using Animators;
using Characters;
using Characters.Movement;
using General;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Stats))]
    public class Player : MonoBehaviour, IPhysicsCharacter {
        private IMovement movement;
        private IAnimatorFacade animatorFacade;
        [SerializeField] private Rigidbody rbd;
        [SerializeField] private Stats stats;
        [SerializeField] private CameraView cameraView;

        private void Start() {
            rbd = GetComponent<Rigidbody>();
            stats = GetComponent<Stats>();
            movement = new GroundMovement(this);
            animatorFacade = new AnimatorFacade(GetComponentInChildren<ICharacterAnimator>());
        }

        private void FixedUpdate() {
            movement.move(findDirection());
        }

        public IMovement getMovement() {
            return movement;
        }

        public void die() {
            throw new NotImplementedException();
        }

        public Stats getStats() {
            return stats;
        }


        private Vector3 findDirection() {
            switch (cameraView) {
                case CameraView.AlwaysForward:
                    return MovementDirection.getCameraForwardDirection();
                    break;
                default:
                    return MovementDirection.getCameraForwardDirection();
                    break;
            }
        }

        public IAnimatorFacade getAnimatorFacade() {
            return animatorFacade;
        }

        public Rigidbody getRigidbody() {
            return rbd;
        }

        public Transform getTransform() {
            return transform;
        }
    }
}