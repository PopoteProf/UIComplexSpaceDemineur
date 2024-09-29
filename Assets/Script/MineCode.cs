
using System;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MineCode : MineScripte
{
    [SerializeField] private TMP_Text _txtDisplayCode;
    [SerializeField] private TMP_Text _txtPlayerCode;
    [SerializeField] private Button _bpZero;
    [SerializeField] private Button _bpOne;
    [SerializeField] private Button _bpCancel;
    [SerializeField] private Button _bpValidate;

    private string _goodText;
    private string _currentText;
    
    protected void Start() {
        _goodText = String.Empty;
        for (int i= 0;i < 4; i++) {
            if (Random.Range(0, 2) > 0) _goodText += "1";
            else _goodText += "0";
        }
        _txtDisplayCode.text = _goodText;
        _currentText = String.Empty;
        
        UpdateText();

        _bpZero.onClick.AddListener(PressButton0);
        _bpOne.onClick.AddListener(PressButton1);
        _bpCancel.onClick.AddListener(PressButtonReset);
        _bpValidate.onClick.AddListener(PressButtonValidate);
    }

    private void PressButton0() {
        if (_currentText.Length < 4) {
            _currentText += "0";
        }
        UpdateText();
    }

    private void PressButton1() {
        if (_currentText.Length < 4) {
            _currentText += "1";
        }
        UpdateText();
    }

    private void PressButtonReset() {
        _currentText = String.Empty;
        UpdateText();
    }

    private void PressButtonValidate() {
        if (_goodText == _currentText)Desactive();
        else {
            _currentText = String.Empty;
            UpdateText();
            DisplayError();
        }
    }

    private void UpdateText() {
        _txtPlayerCode.text = _currentText;
    }
}