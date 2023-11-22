using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameOverObserver : 
        MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener

    {
        [SerializeField] private GameObject character;
        [SerializeField] private GameManager gameManager;

        public void OnStart()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        public void OnFinish()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}