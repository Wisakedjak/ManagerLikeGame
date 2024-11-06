using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class PlayerObject : MonoBehaviour
    {
        public Player Player { get; private set; }
        
        public void SetPlayer(Player player)
        {
            Player = player;
            Initialize();
        }
        
        [Header("Player UI")]
        [SerializeField] private TextMeshProUGUI playerNameText;
        [SerializeField] private TextMeshProUGUI playerOverallText;
        [SerializeField] private TextMeshProUGUI playerNumberText;
        [SerializeField] private Image playerImage;

        private void Initialize()
        {
            playerNameText.text = Player.PlayerName;
            playerOverallText.text = Player.PlayerOverall.ToString();
            playerNumberText.text = Player.PlayerJerseyNumber;
            playerImage.sprite = Player.PlayerImage;
        }
    }
}