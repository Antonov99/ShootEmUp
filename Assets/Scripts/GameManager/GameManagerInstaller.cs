using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var manager= GetComponent<GameManager>();
            var listeners = GetComponentsInChildren<Listeners.IGameListener>();
            foreach (var gameListener in listeners)
            { 
                manager.AddListener(gameListener);
            }

        }
    }
}