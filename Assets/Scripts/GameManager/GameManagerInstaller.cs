using UnityEngine;
using System.Collections.Generic;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> monoBehaviours;
        private void Awake()
        {
            var manager= GetComponent<GameManager>();

            foreach (var gameListener in monoBehaviours)
            {
                var listeners = gameListener.GetComponents<Listeners.IGameListener>();
                foreach (var listener in listeners)
                {
                    manager.AddListener(listener);
                }
               
            }

        }
    }
}