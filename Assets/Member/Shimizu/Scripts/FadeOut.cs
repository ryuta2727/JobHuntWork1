using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FadeOutRS
{
    [RequireComponent(typeof(Image))]
    public class FadeOut : MonoBehaviour
    {
        Image img;
        [Header("FadeOutèIóπÇ…Ç©Ç©ÇÈéûä‘")]
        [SerializeField]
        private float endTimer = 1f;

        private bool fadeout = false;
        private float timer = 0;
        private void Awake()
        {
            img = GetComponent<Image>();
            img.fillAmount = 0;
        }
        public void FadeOutStart()
        {
            img.fillAmount = 0;
            img.color = new Color(0, 0, 0, 1);
            fadeout = true;

        }
        private void Update()
        {
            if (fadeout)
            {
                if(timer < endTimer)
                {
                    img.fillAmount += Time.deltaTime / endTimer;
                    timer += Time.deltaTime;
                }
                else if(timer >= endTimer)
                {
                    FadeOutReset();
                }
            }
        }
        private void FadeOutReset()
        {
            fadeout = false;
            timer = 0;
            //ÉVÅ[ÉìëJà⁄
            Clearmanager.Gameover = true;

        }
    }
}
