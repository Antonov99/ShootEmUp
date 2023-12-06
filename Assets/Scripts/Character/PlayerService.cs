using System;
using UnityEngine;


namespace ShootEmUp
{
    [Serializable]
    public sealed class PlayerService
    {
        [SerializeField] private GameObject character;
        public GameObject Character => character;
    }
}