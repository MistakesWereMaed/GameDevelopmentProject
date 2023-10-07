using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;

    public void onPlayerMovement(InputAction.CallbackContext context)
    {
        playerMovement.setInput(context.ReadValue<float>());
    }

    public void onPlayerJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.playerJump();
        }
    }

    public void onPlayerDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(playerMovement.PlayerDash());
        }
    }

    public void onPlayerLight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerAttack.lightAttack();
        }
    }

    public void onPlayerHeavy(InputAction.CallbackContext context)
    {
        if (context.canceled && context.duration < .4f && context.duration >= .3f)
        {
            playerAttack.lightAttack();
        }
        else if (context.performed)
        {
            playerAttack.heavyAttack();
        }
    }

    public void onPlayerSpecial(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerAttack.specialAttack();
        }
    }

    public void onPlayerChargedSpecial(InputAction.CallbackContext context)
    {
        if (context.canceled && context.duration < .4f && context.duration >= .3f)
        {
            playerAttack.specialAttack();
        }
        else if (context.performed)
        {
            playerAttack.chargedSpecialAttack();
        }
    }
}
