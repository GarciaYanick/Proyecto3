﻿using System;
using UnityEngine;

namespace TopDownCharacter2D.FX
{
    public enum TriggerEvents
    {
        Walk,
        Look,
        Attack,
        Heal,
        Damage,
        Death,
        InvincibilityEnd,
        Pickup
    }

    [Serializable]
    public class Effect
    {
        [Tooltip("The event that causes the effect to be triggered")]
        public TriggerEvents triggerEvent;

        [Tooltip("The particle system played when this effect is triggered")]
        public ParticleSystem particleSystem;

        [Tooltip("The sound effect played when this effect is triggered")]
        public AudioClip soundEffect;

        [Tooltip("Set whether the screen should shake when this effect get triggered")]
        public bool screenShake;
    }
}