using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAttack playerAttack;

    public void OnPlayerMovement(InputAction.CallbackContext context){
        playerMovement.SetInput(context.ReadValue<float>());
    }

    public void OnPlayerJump(InputAction.CallbackContext context){
        if (context.performed){
            playerMovement.PlayerJump();
        }
    }

    public void OnPlayerDash(InputAction.CallbackContext context){
        if (context.performed){
            playerMovement.PlayerDash();
        }
    }

    public void OnPlayerShoot(InputAction.CallbackContext context){
        if (context.performed){
            playerAttack.StartShoot();
        } else if (context.canceled){
            playerAttack.EndShoot();
        }
    }

    public void OnPlayerMelee(InputAction.CallbackContext context){
        if (context.performed){
            playerAttack.Melee();
        }
    }
}
