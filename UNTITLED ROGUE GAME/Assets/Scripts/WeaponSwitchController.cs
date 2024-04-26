using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitchController : MonoBehaviour
{
    private PlayerInput pInput;



    // Start is called before the first frame update
    void Start()
    {
        pInput = gameObject.GetComponent<PlayerInput>();

        //pInput.input;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
