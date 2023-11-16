using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameOverObserver : MonoBehaviour
    {
        [SerializeField] private GameObject character;

        private void OnEnable()
        {
            character.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            character.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _)
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}