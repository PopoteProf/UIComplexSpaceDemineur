using UnityEngine;
using UnityEngine.UI;

public class MineScroll : MineScripte
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _bpValidate;

    protected void Start() {
        _bpValidate.onClick.AddListener(PressValidate);
    }

    private void PressValidate()
    {
        if( _toggle.isOn) Desactive();
        else DisplayError();
    }
}