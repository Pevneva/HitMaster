using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Updater : MonoBehaviour
    {
        private IUpdateListener _listener;

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void Update()
        {
            if (_listener != null)
                _listener.Update(Time.deltaTime);
        }

        public void Init(IUpdateListener listener) =>
            _listener = listener;

        public void Clear() =>
            _listener = null;
    }
}