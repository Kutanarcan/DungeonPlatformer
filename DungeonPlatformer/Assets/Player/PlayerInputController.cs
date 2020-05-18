using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    PlayerController playerController;
    bool inventoryActiveness = true;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();

    }

    void Update()
    {
        playerController.PlayerMovementController.HorizontalAxis = Input.GetAxisRaw("Horizontal");
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.anyKey)
        {
            InputManager.Instance.inputInfo.keyInputDict[InputType.Attack].inputCode.HandleKeyDown(playerController.PlayerAttackController.Attack);
            InputManager.Instance.inputInfo.keyInputDict[InputType.Jump].inputCode.HandleKeyDown(playerController.PlayerMovementController.HandleJump);
            InputManager.Instance.inputInfo.keyInputDict[InputType.Inventory].inputCode.HandleKeyDown(InventoryUI.Instance.SetVisibilityInventoryPanel);
            InputManager.Instance.inputInfo.keyInputDict[InputType.Bomb].inputCode.HandleKeyDown(playerController.PlayerAttackController.SpawnBomb);
            if (Input.GetKeyDown(InputManager.Instance.inputInfo.keyInputDict[InputType.Fireball].inputCode))
            {
                playerController.PlayerAttackController.SpecialAttack(InputType.Fireball);
            }

            if (Input.GetKeyDown(InputManager.Instance.inputInfo.keyInputDict[InputType.Icebolt].inputCode))
            {
                playerController.PlayerAttackController.SpecialAttack(InputType.Icebolt);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlayerEvents.OnPlayerTakeDamageFunction(7.5f);
            }
        }
    }


}
