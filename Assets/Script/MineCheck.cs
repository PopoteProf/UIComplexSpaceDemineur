using UnityEngine;
using UnityEngine.UI;

public class MineCheck : MineScripte
{
    [SerializeField] private Toggle _toggle1;
    [SerializeField] private Toggle _toggle2;
    [SerializeField] private Toggle _toggle3;
    [SerializeField] private Toggle _toggle4;
    [SerializeField] private Toggle _toggle5;
    [SerializeField] private Toggle _toggle6;
    [SerializeField] private Image _img1;
    [SerializeField] private Image _img2;
    [SerializeField] private Image _img3;
    [SerializeField] private Image _img4;
    [SerializeField] private Image _img5;
    [SerializeField] private Image _img6;
    [SerializeField] private Button _bpValidate;
    [SerializeField] private Color _colorValide = Color.green;
    [SerializeField] private Color _colorError = Color.red;


    private bool _value1;
    private bool _value2;
    private bool _value3;
    private bool _value4;
    private bool _value5;
    private bool _value6;
    protected void Start() 
    {
        _bpValidate.onClick.AddListener(PressValidate);
        if (Random.Range(0, 2) > 0) {
            _value1 = true;
            _img1.color = _colorError;
        }
        else _img1.color = _colorValide;
        
        if (Random.Range(0, 2) > 0) {
            _value2 = true;
            _img2.color = _colorError;
        }
        else _img2.color = _colorValide;
        
        if (Random.Range(0, 2) > 0) {
            _value3 = true;
            _img3.color = _colorError;
        }
        else _img3.color = _colorValide;
        
        if (Random.Range(0, 2) > 0) {
            _value4 = true;
            _img4.color = _colorError;
        }
        else _img4.color = _colorValide;
        
        if (Random.Range(0, 2) > 0) {
            _value5 = true;
            _img5.color = _colorError;
        }
        else _img5.color = _colorValide;
        
        if (Random.Range(0, 2) > 0) {
            _value6 = true;
            _img6.color = _colorError;
        }
        else _img6.color = _colorValide;
    }

    private void PressValidate()
    {
        if( CheckIfGood())Desactive();
        else DisplayError();
    }

    private bool CheckIfGood() {
        if (_toggle1.isOn!=_value1)
        {
            print("value1");
            return false;
        }
        if (_toggle2.isOn != _value2) 
        {
            print("value2");
            return false;
        }
        if (_toggle3.isOn != _value3) 
        {
            print("value3");
            return false;
        }
        if (_toggle4.isOn != _value4) 
        {
            print("value4");
            return false;
        }
        if (_toggle5.isOn != _value5) 
        {
            print("value5");
            return false;
        }
        if (_toggle6.isOn != _value6) 
        {
            print("value6");
            return false;
        }
        return true;
    }
}