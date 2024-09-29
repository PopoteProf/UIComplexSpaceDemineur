using UnityEngine;
using UnityEngine.UI;

public class MineMonoCheck : MineScripte {
    [SerializeField] private Toggle _toggle1;
    [SerializeField] private Toggle _toggle2;
    [SerializeField] private Toggle _toggle3;
    [SerializeField] private Toggle _toggle4;
    [SerializeField] private Button _bpValidate;
    
    private int _value;
  
    protected void Start() {
        _value = Random.Range(0, 4);
        _bpValidate.onClick.AddListener(PressValidate);
    }

    private void PressValidate()
    {
        if( CheckIfGood())Desactive();
        else DisplayError();
    }

    private bool CheckIfGood() {
        switch (_value) {
            case 0: if (_toggle1.isOn) return true; break;
            case 1: if (_toggle2.isOn) return true; break;
            case 2: if (_toggle3.isOn) return true; break;
            case 3: if (_toggle4.isOn) return true; break;
        }
        return false;
    }
}