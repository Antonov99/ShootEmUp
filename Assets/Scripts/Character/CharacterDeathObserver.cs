using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : 
        MonoBehaviour,
        GameListeners.IGameStartListener,
        GameListeners.IGameFinishListener

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