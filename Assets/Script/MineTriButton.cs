using UnityEngine;
using UnityEngine.UI;

public class MineTriButton : MineScripte
{
    [Space(10)] [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    
    private int _goodButton;
    protected override void Start()
    {
        _button1.onClick.AddListener(PressButton1);
        _button2.onClick.AddListener(PressButton2);
        _button3.onClick.AddListener(PressButton3);
        _goodButton = Random.Range(0, 3);
    }
    
    private void PressButton1(){PressButton(0);}
    private void PressButton2(){PressButton(1);}
    private void PressButton3(){PressButton(2);}
    
    private void PressButton(int id) {
        if(id == _goodButton) Desactive();
        else DisplayError();
    }
}