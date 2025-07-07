using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Tweening : MonoBehaviour
{

    public void OutInScale(GameObject objectToScale)
    {
        objectToScale.SetActive(true);
        objectToScale.transform.localScale = Vector3.zero;
        var sequence = DOTween.Sequence();
        var image = objectToScale.GetComponent<Image>();
        sequence.Append(objectToScale.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutCubic));
        sequence.Join(image.DOColor(Random.ColorHSV(),2));
    }
    public async void InOutScale(GameObject objectToScale)
    {
       await objectToScale.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InCubic).AsyncWaitForCompletion();
       objectToScale.SetActive(false);
    }

    public void OutItFade(GameObject objectToScale)
    {
        var mat = objectToScale.GetComponent<Image>();
        mat.color = new Color(mat.color.r,mat.color.g,mat.color.b,0);
        objectToScale.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(mat.DOFade(1, 0.3f));
        sequence.Join(mat.DOColor(Random.ColorHSV(),0.25f));
    }

    public async void InOutFade(GameObject objectToScale)
    {
        var mat = objectToScale.GetComponent<Image>();
        await mat.DOFade(0, 0.5f).AsyncWaitForCompletion();
        objectToScale.SetActive(false);
    }
}