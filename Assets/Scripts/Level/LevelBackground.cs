using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class LevelBackground : 
        MonoBehaviour,
        GameListeners.IGameFixedUpdateListener
    {
        private float startPositionY;

        private float endPositionY;

        private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private Transform myTransform;

        [FormerlySerializedAs("m_params")] [SerializeField] private Params @params;

        private void Awake()
        {
            startPositionY = @params.startPositionY;
            endPositionY = @params.endPositionY;
            movingSpeedY = @params.movingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [FormerlySerializedAs("m_startPositionY")] [SerializeField] public float startPositionY;

            [FormerlySerializedAs("m_endPositionY")] [SerializeField] public float endPositionY;

            [FormerlySerializedAs("m_movingSpeedY")] [SerializeField] public float movingSpeedY;
        }
    }
}