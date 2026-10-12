using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class LevelDoor : MonoBehaviour {
    [SerializeField] private MineScripte[] _mines;
    [SerializeField] private CinemachineCamera _camera;

    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject _canvasLocked;
    [SerializeField] private TMP_Text _txtCount;
    [SerializeField] private GameObject _canvasUnlocked;
    [SerializeField] private Button _OpenButton;

    private bool _doorIsOpen;
    private bool _isDoorUnlock;
    private int _mineToUnlock;
    private int _unLockedMines;
    
    
    
    private void Start() {
        _OpenButton.onClick.AddListener(OpenDoor);
        
        if (_mines == null || _mines.Length <= 0) return;
        foreach (var mine in _mines) {
            if (mine == null) continue;
            _mineToUnlock++;
            mine.OnMineDeactivated += MineOnMineDeactivated;
            mine.OnMineExploded += MineOnMineExploded;
        }
    }

    private void OpenDoor()
    {
        _doorIsOpen = true;
        _animator.SetTrigger("Open");
        _camera.gameObject.SetActive(false);
        if (_isDoorUnlock) {
            _canvasUnlocked.SetActive(false);
        }
        else {
            _canvasLocked.SetActive(false);
        }
    }

    private void MineOnMineExploded(object sender, EventArgs e) {
        _mineToUnlock--;
        CheckIfDoorUnlock();
    }

    private void MineOnMineDeactivated(object sender, EventArgs e) {
        _unLockedMines++;
        CheckIfDoorUnlock();
    }

    private void CheckIfDoorUnlock() {
        _isDoorUnlock =_unLockedMines >= _mineToUnlock;
        if( _isDoorUnlock ) StaticData.DoDoorUnlock();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (_doorIsOpen) return;
        if (other.transform.CompareTag("Player")) {
            _camera.gameObject.SetActive(true);
            if (_isDoorUnlock) {
                _canvasUnlocked.SetActive(true);
                
            }
            else {
                _txtCount.text = _unLockedMines +"/" + _mineToUnlock;
                _canvasLocked.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (_doorIsOpen) return;
        if (other.transform.CompareTag("Player")) {
            _camera.gameObject.SetActive(false);
            if (_isDoorUnlock) {
                _canvasUnlocked.SetActive(false);
            }
            else {
                _canvasLocked.SetActive(false);
            }
        }
    }
}