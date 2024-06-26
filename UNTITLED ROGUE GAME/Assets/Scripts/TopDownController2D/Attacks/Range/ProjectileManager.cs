﻿using UnityEngine;

namespace TopDownCharacter2D.Attacks.Range
{
    public class ProjectileManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _impactParticleSystem;
        public static ProjectileManager instance;

        private ObjectPool _projectilesPool;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _projectilesPool = ObjectPool.sharedInstance;
        }

        public void CreateImpactParticlesAtPosition(Vector3 position, RangedAttackConfig config)
        {
            _impactParticleSystem.transform.position = position;
            ParticleSystem.EmissionModule em = _impactParticleSystem.emission;
            em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(config.size * 5f)));
            ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
            mainModule.startSpeedMultiplier = config.size * 10f;
            _impactParticleSystem.Play();
        }

        public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackConfig config)
        {
            GameObject projectileObject = _projectilesPool.GetPooledObject();

            projectileObject.transform.position = startPosition;
            RangedAttackController rangedAttack = projectileObject.GetComponent<RangedAttackController>();
            rangedAttack.InitializeAttack(direction, config, this);

            projectileObject.SetActive(true);
        }
    }
}