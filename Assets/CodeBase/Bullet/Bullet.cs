using System.Collections;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class Bullet : MonoBehaviour
    {
        private const int LifeTime = 3;
        
        private Coroutine _enablingCoroutine;
        private Transform _playerTransform;

        public void Construct(Transform player) => 
            _playerTransform = player;

        private void OnEnable() => 
            _enablingCoroutine = StartCoroutine(routine: StartEnablingTimer());

        private void OnDisable()
        {
            if (_enablingCoroutine != null) 
                StopCoroutine(routine: _enablingCoroutine);
        }

        private IEnumerator StartEnablingTimer()
        {
            yield return new WaitForSeconds(seconds: LifeTime);
            gameObject.SetActive(value: false);
            transform.parent = _playerTransform;
        }
    }
}