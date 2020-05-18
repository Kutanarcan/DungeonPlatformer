using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsPauseButtonActive { get; private set; }

    [SerializeField]
    GameObject player;
    [SerializeField]
    CinemachineVirtualCamera inGameCamera;
    [SerializeField]
    Transform playerFirstSpawnPos;

    GameObject tmpPlayer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        tmpPlayer = ObjectPooler.Instance.SpawnPoolObject(player.name, playerFirstSpawnPos.position, Quaternion.identity);
        inGameCamera.Follow = tmpPlayer.transform;
        Load();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        UI_Base.Instance.InGameUIController.OpenPauseMenu();
    }

    public void BackToMainMenu()
    {
        InGameEvents.OnMainMenuButtonPressedFunction();
        PlayerController.Instance.ResetToDefaults();
        ObjectPooler.Instance.ReturnToPool(tmpPlayer.name, tmpPlayer);
        TimeManager.timeScale = 1;

        StartCoroutine(LoadSceneWithASyncCoroutine());
    }

    IEnumerator LoadSceneWithASyncCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(FadeSceneController.MAIN_MENU);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Save()
    {
        PlayerController.Instance.PlayerSaveController.SavePlayerData();
    }

    public void Load()
    {
        PlayerController.Instance.PlayerSaveController.LoadAllPlayerData();
    }
}
