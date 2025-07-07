using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextTweener : MonoBehaviour
{
    public void OutInFade(TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r,text.color.g,text.color.b,0);
        text.DOFade(1, 0.3f);
    }
    public  void InOutFade(TextMeshProUGUI text)
    {
        text.DOFade(0, 0.15f);
    }
    
    public void OutInScale(TextMeshProUGUI text)
    {
        text.transform.DOScale(1, 0.55f);
    }
    public  void InOutScale(TextMeshProUGUI text)
    {
        text.transform.DOScale(0, 0.35f);
    }
}