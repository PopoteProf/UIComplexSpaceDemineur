using System;
using UnityEngine;

public class UILoseAnnoncer : MonoBehaviour {
    [SerializeField] private GameObject _panel;

    public void Start() {
        StaticData.OnPlayerLose += StaticDataOnPlayerLose;
    }
    public void OnDestroy() {
        StaticData.OnPlayerLose -= StaticDataOnPlayerLose;
    }

    private void StaticDataOnPlayerLose(object sender, EventArgs e)
    {
        _panel.SetActive(true);
    }
}