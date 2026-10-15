using System;
using UnityEngine;

public class UIWinAnnoncer : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Start() {
        StaticData.OnPlayerWin += StaticDataOnPlayerWin;
    }
    public void OnDestroy() {
        StaticData.OnPlayerWin -= StaticDataOnPlayerWin;
    }

    private void StaticDataOnPlayerWin(object sender, EventArgs e)
    {
        _panel.SetActive(true);
    }
}