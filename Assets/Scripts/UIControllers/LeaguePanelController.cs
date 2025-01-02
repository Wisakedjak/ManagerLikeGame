using UnityEngine;

namespace ManagerLikeGame.UIControllers
{
    public class LeaguePanelController : MonoBehaviour
    {
        [Header("Serialize Fields")]
        [SerializeField] private GameObject leaguePrefab;
        [SerializeField] private Transform leagueParent;
        
        public LeagueObject CreateLeague(League league)
        {
            LeagueObject leagueGo = Instantiate(leaguePrefab, leagueParent).GetComponent<LeagueObject>();
            leagueGo.SetLeague(league);
            return leagueGo;
        }
        
        private void OnDisable()
        {
            foreach (Transform child in leagueParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}