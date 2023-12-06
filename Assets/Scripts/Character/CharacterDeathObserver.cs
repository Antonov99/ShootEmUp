using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : IInitializable,IDisposable
    {
        private PlayerService playerService;
        private GameManager gameManager;

        [Inject]
        public void Construct(PlayerService playerService,GameManager gameManager)
        {
            this.playerService = playerService;
            this.gameManager = gameManager;
        }

        public void Initialize()
        {
            playerService.Character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        public void Dispose()
        {
            playerService.Character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}