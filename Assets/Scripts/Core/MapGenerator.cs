using System;
using UnityEngine;

namespace Core
{
    public class MapGenerator : MonoBehaviour
    {
        public GameObject mapPartPrefab;
        public Transform objectTransform;
        public Vector3 spawnOffset;
        public GameObject originPoint;
        public Transform partsParent;

        private GameObject _beforePlatform;
        private GameObject _currentPlatform;
        private GameObject _nextPlatform;
        private int spawnIndex;


        private void Start()
        {
            SetUp();
        }

        private void SetUp()
        {
            ClearPlatforms();
            spawnIndex = 0;
            _beforePlatform = null;
            _currentPlatform = originPoint;
            _nextPlatform = SpawnPlatrform(spawnIndex + 1);
        }

        private void ClearPlatforms()
        {
            var plats = new[] {_beforePlatform, _currentPlatform, _nextPlatform};
            foreach (var i in plats)
            {
                if (i is null) continue;
                if (i != originPoint) Destroy(i);
            }

            _beforePlatform = null;
            _currentPlatform = null;
            _nextPlatform = null;
        }

        private GameObject SpawnPlatformNext()
        {
            return SpawnPlatrform(spawnIndex + 1);
        }

        private GameObject SpawnPlatformBefore()
        {
            return SpawnPlatrform(spawnIndex - 1);
        }

        private GameObject SpawnPlatrform(int index)
        {
            var obj = Instantiate(mapPartPrefab, partsParent, true);
            obj.transform.position = originPoint.transform.position + spawnOffset * index;
            return obj;
        }

        private void OnStepBack()
        {
            spawnIndex--;
            Destroy(_nextPlatform);
            _nextPlatform = _currentPlatform;
            _currentPlatform = _beforePlatform;
            if (spawnIndex > 1)
            {
                _beforePlatform = SpawnPlatformBefore();
            }
            else if (spawnIndex == 1)
            {
                _beforePlatform = originPoint;
            }
            else
            {
                _beforePlatform = null;
            }
        }

        private void OnStepForward()
        {
            spawnIndex++;
            if (_beforePlatform != originPoint) Destroy(_beforePlatform);
            _beforePlatform = _currentPlatform;
            _currentPlatform = _nextPlatform;
            _nextPlatform = SpawnPlatformNext();
        }

        public void FixedUpdate()
        {
            PlatformUpdate();
        }

        private void PlatformUpdate()
        {
            var point = objectTransform.position.x;
            var distCurrent = Math.Abs(_currentPlatform.transform.position.x - point);
            var distAfter = Math.Abs(_nextPlatform.transform.position.x - point);
            if (distCurrent > distAfter)
            {
                OnStepForward();
            }

            if (_beforePlatform is null) return;
            var distBefore = Math.Abs(_beforePlatform.transform.position.x - point);
            if (distCurrent > distBefore)
            {
                OnStepBack();
            }
        }
    }
}