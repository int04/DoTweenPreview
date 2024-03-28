using DG.Tweening;
using TMPro;
using UnityEngine;

namespace script
{
    public class ChildControllers : MonoBehaviour
    {
        private float _speed = 1f;

        [SerializeField] private GameObject images;
        [SerializeField] private TextMeshProUGUI text;
        private Ease _ease = Ease.Linear;

        public void UpdateEase(Ease t)
        {
            _ease = t;
        }
        public void UpdateTime(float t)
        {
            _speed = t;
        }
        public void Run(Ease t)
        {
            if (images && images.GetComponent<RectTransform>())
            {
                var p = images.GetComponent<RectTransform>();
                p.DOAnchorPosY(-104f, _speed).SetLoops(-1, LoopType.Yoyo).SetEase(t);
                    //.SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
            }
            text.text = _ease.ToString();
        }

        public void Coppy()
        {
            string str = text.text;
            GUIUtility.systemCopyBuffer = str;
        }


    }
}