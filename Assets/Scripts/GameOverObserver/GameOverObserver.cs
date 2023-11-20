using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameOverObserver : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private GameManager gameManager;

        private void OnEnable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _)
        {
            gameManager.GameOver();
        }
    }
}