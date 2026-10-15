using System;
using DG.Tweening;
using UnityEngine;

public class UILoseAnnoncer : MonoBehaviour {
    [SerializeField] private GameObject _panel;
    public CanvasGroup _canvasGroup;
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
        _canvasGroup.DOFade(1,  ActivationTime);
    }
}