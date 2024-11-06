using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class TeamObject : MonoBehaviour
    {
        public Team Team { get; private set; }
        
        public void SetTeam(Team team)
        {
            Team = team;
            Initialize();
        }
        
        [Header("Team UI")]
        [SerializeField] private TextMeshProUGUI teamNameText;
        [SerializeField] private TextMeshProUGUI teamPrestigeText;
        [SerializeField] private TextMeshProUGUI teamOffenceText;
        [SerializeField] private TextMeshProUGUI teamDefenceText;
        [SerializeField] private TextMeshProUGUI teamStaminaText;
        [SerializeField] private Image teamImage;
        public GameObject selectedImage;
        [SerializeField] private Button selectButton;
        
        public event Action<TeamObject> OnSelectButtonClicked;
        
        
        
        private void Initialize()
        {
            teamNameText.text = Team.TeamName;
            teamPrestigeText.text = Team.TeamPrestige.ToString();
            teamOffenceText.text = Team.TeamOffence.ToString();
            teamDefenceText.text = Team.TeamDefence.ToString();
            teamStaminaText.text = Team.TeamStamina.ToString();
            teamImage.sprite = Team.TeamLogo;
            selectButton.onClick.AddListener(SelectButtonClicked);
        }

        private void SelectButtonClicked()
        {
            selectedImage.SetActive(true);
            OnSelectButtonClicked?.Invoke(this);
        }
    }
}