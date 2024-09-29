using UnityEngine;
using UnityEngine.UI;

public class MinePanelScroll : MineScripte
{
    [SerializeField] private Transform _scrollPanel;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _bpValidate;
    [SerializeField] private float _minY = -5;
    [SerializeField] private float _maxY = 5;

    protected void Start() {
        _slider.onValueChanged.AddListener(ChangeValue);
        _bpValidate.onClick.AddListener(Desactive);
    }

    private void ChangeValue(float value) {
        Vector3 pos = _scrollPanel.localPosition;
        pos.y = Mathf.Lerp(_minY, _maxY, _slider.value);
        _scrollPanel.localPosition = pos;
    }
    
}