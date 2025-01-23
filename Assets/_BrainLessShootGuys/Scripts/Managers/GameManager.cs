using UnityEngine;
using BaseTemplate.Behaviours;
using UnityEngine.InputSystem;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{    
    public PlayerInputManager _PlayerInputManager;
    public List<PlayerInfo> _PlayerList;
    public int _NumberOfKills;
    public int _MaxNumberOfKill;
    public int _ActualRound;

    [Header("MeshMat")]
    public List<Material> MeshMat;
    public List<Material> playerMaterial;
    public List<Material> playerArrowMaterial;

    [Header("Player spawn Points")]
    [SerializeField]private List<Transform> spawnsTransform;
    [HideInInspector]public List<Transform> FreeSpawnsTransform;

    [Header("UI Panels")]
    public GameObject _WaitingPanel;

    [Serializable]
    public struct PlayerInfo
    {
        public PlayerInput playerInput;
        public int playerScore;

        public void Add(int score)
        {
            playerScore += score;
        }
    }

    private void Awake()
    {
        /*_ManagerInfo = ScriptableObject.CreateInstance<ManagerInfo>();
        _ManagerInfo.Init(); */
        
        FreeSpawnsTransform = spawnsTransform;
    }

    public void SpawnPlayer(PlayerInput playerInput)
    {
        if(FreeSpawnsTransform.Count <= 0)
        {
            FreeSpawnsTransform = spawnsTransform;
        }

        Transform position = FreeSpawnsTransform[UnityEngine.Random.Range(0, FreeSpawnsTransform.Count)];
        FreeSpawnsTransform.Remove(position);

        playerInput.transform.position = position.position;
    }

    public void AddPlayer(PlayerInput player)
    {
        PlayerInfo playerTemp = new PlayerInfo();
        playerTemp.playerInput = player;
        playerTemp.playerScore = 0;
        _PlayerList.Add(playerTemp);   
        
        if(playerTemp.playerInput.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            playerMovement.skullRenderer.material = playerMaterial[_PlayerList.IndexOf(playerTemp)];

            foreach (MeshRenderer meshArrow in playerMovement.arrowRenderers)
            {
                meshArrow.material = playerArrowMaterial[_PlayerList.IndexOf(playerTemp)];
            }
            playerMovement.Init(MeshMat[_PlayerList.IndexOf(playerTemp)]);
        }

        if(_PlayerList.Count > 1 ) 
        {
            _WaitingPanel.SetActive(false);
            StartGame();
        }
    }

    public void StartGame()
    {
        foreach(PlayerInfo player in _PlayerList )
        {
            if(player.playerInput.TryGetComponent<PlayerMovement>(out  var playerMovement))
            {
                SpawnPlayer(player.playerInput);
                playerMovement._CanMove = true;
                playerMovement.InstantiateBasicPistol();
                playerMovement.isEquipWeapon = false;
            }
        }
    }

    public void EndGame()
    {
        if(_NumberOfKills >= _MaxNumberOfKill)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void AddPoint(PlayerInput player)
    {
        foreach (PlayerInfo plr in _PlayerList)
        {
            if (plr.playerInput == player)
            {
                plr.Add(1);
            }
        }
    }
}
