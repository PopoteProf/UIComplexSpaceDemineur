using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MineLevel : MineScripte {
    
    [SerializeField] private Image _imgDisplay;
    [SerializeField] private Color _colorFar = Color.red;
    [SerializeField] private Color _colorClose = new Color(1,0.5f,0);
    [SerializeField] private float _closeRange = 0.4f;
    [SerializeField] private Color _colorOnPoint = Color.green;
    [SerializeField] private float _OnPointRange = 0.15f;
    [SerializeField] private Slider _slider1;
    [SerializeField] private Slider _slider2;
    [SerializeField] private Button _bpDesactiver;

    private float _currentValue;
    private float _correctValue;

    protected override void Start() {
        _correctValue = Random.Range(1, 9f);
        _currentValue = 0;
        _bpDesactiver.onClick.AddListener(UIDesactivate);
        _slider1.onValueChanged.AddListener(ChangeSliderValue);
        _slider2.onValueChanged.AddListener(ChangeSliderValue);
    }

    public void ChangeSliderValue(float val) {
        _currentValue = _slider1.value + _slider2.value;

        _imgDisplay.fillAmount = _currentValue / 10; 

        float dif = Mathf.Abs(_correctValue - _currentValue);
        if (dif <= _OnPointRange) _imgDisplay.color = _colorOnPoint;
        else if(dif <= _closeRange)_imgDisplay.color = _colorClose;
        else _imgDisplay.color = _colorFar;
    }

    public void UIDesactivate() {
        if (Mathf.Abs(_correctValue - _currentValue) <= _OnPointRange) {
            Desactive();
        }
        else {
            DisplayError();
        }
    }
}