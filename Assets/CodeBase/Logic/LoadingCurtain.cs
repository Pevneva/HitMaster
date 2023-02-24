using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private void Awake() => 
            DontDestroyOnLoad(target: this);

        public void Show()
        {
            gameObject.SetActive(value: true);
            Curtain.alpha = 1;
        }
    
        public void Hide() => StartCoroutine(routine: DoFadeIn());
    
        private IEnumerator DoFadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(seconds: 0.03f);
            }
      
            gameObject.SetActive(value: false);
        }
    }
}