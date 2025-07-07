using DG.Tweening;
using UnityEngine;
public class UiAnimator 
{
    public void ScaleOutIn(Transform gameObjectTransform,float animationTime)
    {
        gameObjectTransform.DOScale(new Vector3(1f, 1f, 1f), animationTime).SetEase(Ease.OutCubic);
    }
    public void ScaleInOut(Transform gameObjectTransform,float animationTime)
    {
        gameObjectTransform.DOScale(new Vector3(0,0,0), animationTime).SetEase(Ease.OutCubic).AsyncWaitForCompletion();
    }

    public void DestroyAllTweens(Transform obj)
    {
        obj.DOKill(obj);
    }
}