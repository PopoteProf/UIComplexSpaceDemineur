using System;
using UnityEngine;
using DG.Tweening;

public class UILoseAnnoncer : MonoBehaviour {
    [SerializeField] private GameObject _panel;
    public CanvasGroup canvasGroup;
    public float ActivationTime = 1;

    public void Start() {
        StaticData.OnPlayerLose += StaticDataOnPlayerLose;
    }
    public void OnDestroy() {
        StaticData.OnPlayerLose -= StaticDataOnPlayerLose;
    }

    private void StaticDataOnPlayerLose(object sender, EventArgs e)
    {
        _panel.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, ActivationTime);
    
    }
}