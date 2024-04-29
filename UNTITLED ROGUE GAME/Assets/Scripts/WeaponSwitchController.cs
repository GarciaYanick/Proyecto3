using System;
using System.Collections;
using System.Collections.Generic;
using TopDownCharacter2D;
using TopDownCharacter2D.Attacks.Melee;
using TopDownCharacter2D.Controllers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class WeaponSwitchController : MonoBehaviour
{
    private TopDownCharacterController _controller;

    
    [SerializeField] private GameObject _weaponSprite;
    [SerializeField] private GameObject _bulletSpawnPoint;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.RangeWeaponEvent.AddListener(RangeModeOn());
        _controller.MeleeWeaponEvent.AddListener(MeleeModeOn());
    }

    private UnityAction<Boolean> RangeModeOn()
    {
        gameObject.GetComponent<TopDownShooting>().enabled = true;
        gameObject.GetComponent<TopDownAimRotation>().enabled = true;

        gameObject.GetComponent<MeleeAttackController>().enabled = false;
        gameObject.GetComponent<TopDownMelee>().enabled = false;

        _weaponSprite.SetActive(true);
        _weaponSprite.SetActive(true);

        return RangeModeOn();
    }

private UnityAction<bool> MeleeModeOn()
    {
        gameObject.GetComponent<TopDownShooting>().enabled = false;
        gameObject.GetComponent<TopDownAimRotation>().enabled = false;

        gameObject.GetComponent<MeleeAttackController>().enabled = true;
        gameObject.GetComponent<TopDownMelee>().enabled = true;

        _weaponSprite.SetActive(false);
        _weaponSprite.SetActive(false);

        return MeleeModeOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
