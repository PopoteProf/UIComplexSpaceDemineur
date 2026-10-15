using System;
using DG.Tweening;
using UnityEngine;

public class UILoseAnnoncer : MonoBehaviour {
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _lifeTime = 1f;
    [SerializeField] private Vector3 _endSize = new Vector3(1f, 1f, 1f);
    [SerializeField] private Vector3 _endRotation = new Vector3(0f, 0f, 0f);
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Start() {
        StaticData.OnPlayerLose += StaticDataOnPlayerLose;
    }
    public void OnDestroy() {
        StaticData.OnPlayerLose -= StaticDataOnPlayerLose;
    }

    private void StaticDataOnPlayerLose(object sender, EventArgs e)
    {
        _panel.SetActive(true);
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _lifeTime);
    }
}