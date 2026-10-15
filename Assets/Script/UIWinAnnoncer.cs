using System;
using DG.Tweening;
using UnityEngine;

public class UIWinAnnoncer : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    [SerializeField] private float _activationAlpha = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _activationAnimationTime = 1f;
    
    
    // [SerializeField] private Vector3 _activationScale = Vector3.one;
    // [SerializeField] private AnimationCurve  _activationCurve;

    public void Start() {
        StaticData.OnPlayerWin += StaticDataOnPlayerWin;
    }
    public void OnDestroy() {
        StaticData.OnPlayerWin -= StaticDataOnPlayerWin;
    }

    private void StaticDataOnPlayerWin(object sender, EventArgs e)
    {
        _panel.SetActive(true);
        _canvasGroup.DOFade(_activationAlpha, _activationAnimationTime);
    }
}