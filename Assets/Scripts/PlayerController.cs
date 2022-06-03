using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touchAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["Click"];
        touchAction.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //delegate 'Action<InputAction.CallbackContext>' is a struct
        touchAction.started += OnClicked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClicked(InputAction.CallbackContext context)
    {
        Debug.Log("Click Click");
        //touchAction.started -= OnClicked;
    }
}
