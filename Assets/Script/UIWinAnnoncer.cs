using System;
using UnityEngine;
using DG.Tweening;

public class UIWinAnnoncer : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Vector3 _endSize = new Vector3(1f, 1f, 1f);
    [SerializeField] private Vector3 _endRotation = new Vector3(0f, 0f, 0f);

    public void Start() {
        StaticData.OnPlayerWin += StaticDataOnPlayerWin;
        transform.DOScale(_endSize, _lifeTime);
        
    }
    public void OnDestroy() {
        StaticData.OnPlayerWin -= StaticDataOnPlayerWin;
    }

    private void StaticDataOnPlayerWin(object sender, EventArgs e)
    {
        _panel.SetActive(true);
    }
}