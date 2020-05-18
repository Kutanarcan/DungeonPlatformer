using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public PlayerAnimationController PlayerAnimationController { get; private set; }

    public PlayerInputController PlayerInputController { get; private set; }
    public PlayerMovementController PlayerMovementController { get; private set; }
    public PlayerAttackController PlayerAttackController { get; private set; }
    public PlayerDamageController PlayerDamageController { get; private set; }
    public PlayerSkillController PlayerSkillController { get; private set; }
    public PlayerInventory PlayerInventory { get; private set; }
    public PlayerSaveController PlayerSaveController { get; private set; }

    public HealthDisplayController HealthDisplayController { get; private set; }
    public HealthController HealthController { get; private set; }

    public ConsumableItem item;
    public ConsumableItem item2;
    public EquipableItem item3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        PlayerMovementController = GetComponent<PlayerMovementController>();
        PlayerInputController = GetComponent<PlayerInputController>();
        PlayerAnimationController = GetComponent<PlayerAnimationController>();
        PlayerAttackController = GetComponent<PlayerAttackController>();
        PlayerDamageController = GetComponent<PlayerDamageController>();
        PlayerSkillController = GetComponent<PlayerSkillController>();
        PlayerInventory = GetComponent<PlayerInventory>();
        PlayerSaveController = GetComponent<PlayerSaveController>();

        HealthDisplayController = GetComponent<HealthDisplayController>();
        HealthController = GetComponent<HealthController>();
    }

    public void ResetToDefaults()
    {
        PlayerInputController.enabled = true;
    }

    void OnEnable()
    {
        InGameEvents.OnGamePaused += InGameEvents_OnGamePaused;
        InGameEvents.OnGameContinue += InGameEvents_OnGameContinue;
        InGameEvents.OnDialogStarted += InGameEvents_OnDialogStarted;
        InGameEvents.OnDialogEnded += InGameEvents_OnDialogEnded;
    }

    private void InGameEvents_OnDialogEnded()
    {
        PlayerInputController.enabled = true;
        TimeManager.timeScale = 1;
    }

    private void InGameEvents_OnDialogStarted()
    {
        PlayerInputController.enabled = false;
        TimeManager.timeScale = 0;
    }

    private void InGameEvents_OnGameContinue()
    {
        PlayerInputController.enabled = true;
    }

    private void InGameEvents_OnGamePaused()
    {
        PlayerInputController.enabled = false;
    }

    void OnDisable()
    {
        InGameEvents.OnGamePaused -= InGameEvents_OnGamePaused;
        InGameEvents.OnGameContinue -= InGameEvents_OnGameContinue;
    }

    private void Update()
    {
        KeyCode.H.HandleKeyDown(() => { Inventory.Instance.AddItem(item); });
        KeyCode.M.HandleKeyDown(() => { Inventory.Instance.AddItem(item2); });
        KeyCode.J.HandleKeyDown(() => { Inventory.Instance.AddItem(item3); });
    }
}
