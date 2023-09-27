using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    [HideInInspector] public float vertical = 0, horizontal = 0, mouseX = 0, mouseY = 0;

    [HideInInspector] public bool m1 = false, m2 = false, esc = false, interact = false;

    private void Awake() {
        if(instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static PlayerInput GetInstance(){
        return instance;
    }

    private void Update() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        m1 = Input.GetButton("Fire1");
        m2 = Input.GetButton("Fire2");

        esc = Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P);

        interact = Input.GetButtonDown("Interact") || Input.GetKeyDown(KeyCode.E);
    }
}
