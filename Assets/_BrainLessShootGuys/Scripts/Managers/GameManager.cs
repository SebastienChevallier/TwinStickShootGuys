using UnityEngine;
using BaseTemplate.Behaviours;
using UnityEngine.InputSystem;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public PlayerInfo _Player;
    public int _NumberOfKills;
    public int _MaxNumberOfKill;
    public int _ActualRound;

    [Header("Player spawn Points")]
    [SerializeField]private List<Transform> spawnsTransform;
    [HideInInspector]public List<Transform> FreeSpawnsTransform;    

    [Serializable]
    public struct PlayerInfo
    {
        public PlayerMovement player;
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

        StartGame();
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

    public void SpawnEnnemy()
    {

    }

    /*public void AddPlayer(PlayerInput player)
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
    }*/

    public void StartGame()
    {
            if (_Player.player)
            {
                SpawnPlayer(_Player.playerInput);
                _Player.player._CanMove = true;
                _Player.player.InstantiateBasicPistol();
                _Player.player.isEquipWeapon = false;
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
        if (_Player.playerInput == player)
        {
            _Player.Add(1);
        }
    }
}
