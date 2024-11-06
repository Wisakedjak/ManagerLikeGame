using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class PlayerSubstituteObject : MonoBehaviour
    {
        public Player Player { get; private set; }
        
        public void SetPlayer(Player player)
        {
            Player = player;
            Initialize();
        }
        
        [Header("Player UI")] 
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI playerAgeText;
        [SerializeField] private TextMeshProUGUI playerNationalityText;
        [SerializeField] private TextMeshProUGUI playerPositionText;
        [SerializeField] private TextMeshProUGUI playerOffenceText;
        [SerializeField] private TextMeshProUGUI playerDefenceText;
        [SerializeField] private TextMeshProUGUI playerSpeedText;
        [SerializeField] private TextMeshProUGUI playerStaminaText;
        [SerializeField] private TextMeshProUGUI playerMoraleText;
        [SerializeField] private TextMeshProUGUI playerPassingText;
        [SerializeField] private TextMeshProUGUI playerLeadershipText;
        [SerializeField] private TextMeshProUGUI playerOverallText;
        [SerializeField] private Image playerImage;

        private void Start()
        {
            
        }

        private void Initialize()
        {
            playerNameText.text = Player.PlayerName;
            playerAgeText.text = Player.PlayerAge;
            playerNationalityText.text = Player.PlayerNationality;
            playerPositionText.text = Player.PlayerPosition;
            playerOffenceText.text = Player.PlayerOffence.ToString();
            playerDefenceText.text = Player.PlayerDefence.ToString();
            playerSpeedText.text = Player.PlayerSpeed.ToString();
            playerStaminaText.text = Player.PlayerStamina.ToString();
            playerMoraleText.text = Player.PlayerMorale.ToString();
            playerPassingText.text = Player.PlayerPassing.ToString();
            playerLeadershipText.text = Player.PlayerLeadership.ToString();
            //playerOverallText.text = Player.PlayerOverall.ToString();
            playerImage.sprite = Player.PlayerImage;
        }
        

        
    }
}