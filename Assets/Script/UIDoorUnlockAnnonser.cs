using System;
using UnityEngine;

public class UIDoorUnlockAnnonser : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _displayTime;
    private float _timer;
    private bool _panelIsOn;
    
    private void Start()
    {
        StaticData.OnDoorUnlock+= StaticDataOnDoorUnlock;
    }
    private void OnDestroy()
    {
        StaticData.OnDoorUnlock-= StaticDataOnDoorUnlock;
    }

    private void Update()
    {
        ManagePanelOn();
    }

    private void StaticDataOnDoorUnlock(object sender, EventArgs e) {
        _panelIsOn = true;
        _timer = 0;
        _panel.SetActive(true);
    }

    private void ManagePanelOn() {
        if (!_panelIsOn) return;
        _timer += Time.deltaTime;
        if (_timer >= _displayTime) {
            _panel.SetActive(false);
            _panelIsOn = false;
        }
    }
}