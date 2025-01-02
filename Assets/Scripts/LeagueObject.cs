using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class LeagueObject : MonoBehaviour
    {
       public League League { get; private set; }
       
         public void SetLeague(League league)
         {
              League = league;
              Initialize();
         }
         
            [Header("League UI")]
            [SerializeField] private TextMeshProUGUI leagueNameText;
            [SerializeField] private Image leagueImage;

            [SerializeField] private Button selectButton;
            
            public event Action<LeagueObject> OnSelectButtonClicked;
            
            private void Initialize()
            {
                leagueNameText.text = League.Name;
                leagueImage.sprite = League.Logo;
                selectButton.onClick.AddListener(SelectButtonClicked);
            }
            
            private void SelectButtonClicked()
            {
                OnSelectButtonClicked?.Invoke(this);
            }
    }
}
