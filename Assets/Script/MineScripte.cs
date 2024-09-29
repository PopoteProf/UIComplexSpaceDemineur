using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MineScripte : MonoBehaviour
{
    [SerializeField] private Transform _mainPanel;
    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _xAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    [SerializeField] private AnimationCurve _yAnimationCurve = AnimationCurve.EaseInOut(0,0,1,1);
    [Space(10)]
    [SerializeField] private GameObject _virtualCam;
    [Space(10)]
    [SerializeField] private CanvasGroup _canvasGroupError;
    [SerializeField] private float _errorTime = 1;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private float _alertDistance = 3;
    [SerializeField] private Collider _triggercollider;
    [SerializeField] private Rigidbody _mineRb;
    [SerializeField] private ParticleSystem _psOff;

    
    private Transform _player;
    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (_player != null) {
            if (Vector3.Distance(_player.position, transform.position) < _alertDistance) _animator.SetBool("IsAlert", true);
            else _animator.SetBool("IsAlert", false);
        }
    }
    

    public void Desactive() {
        _psOff.Play();
        _virtualCam.SetActive(false);
        _triggercollider.enabled = false;
        CloseMine();
        _animator.SetBool("Off",true);
        _mineRb.isKinematic = false;
        //Destroy(gameObject);
    }

    
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player"))
        {
            _player = other.transform;
            OpenMine();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.transform.CompareTag("Player")) {
            _player = null;
            CloseMine();
        }
    }
    
    protected void OpenMine() {
        _mainPanel.DOPause();
        _mainPanel.localScale = new Vector3(0,0,1);
        _mainPanel.DOScaleX(1, _animationTime).SetEase(_xAnimationCurve);
        _mainPanel.DOScaleY(1, _animationTime).SetEase(_yAnimationCurve);
        _virtualCam.SetActive(true);
        _animator.SetBool("Control", true);
    }
    protected void CloseMine() {
        _mainPanel.DOPause();
        _mainPanel.localScale = Vector3.one;
        _mainPanel.DOScaleX(0, _animationTime).SetEase(_xAnimationCurve);
        _mainPanel.DOScaleY(0, _animationTime).SetEase(_yAnimationCurve);
        _virtualCam.SetActive(false);
        _animator.SetBool("Control", false);
    }

    protected void DisplayError() {
        _canvasGroupError.DOPause();
        _canvasGroupError.alpha = 1;
        _canvasGroupError.DOFade(0, _errorTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _alertDistance);
    }
}
