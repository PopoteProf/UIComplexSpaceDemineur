using System;
using UnityEngine;
using DG.Tweening;

public class UIHeathPoint : MonoBehaviour {
    [SerializeField] private GameObject[] _heathPoint;
    [SerializeField] private float _lifeTime = 0.5f;
    [SerializeField] private Vector3 _endSize = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 _endRotation = new Vector3(0, 0, 0);
    [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    
    private void Start() {
        StaticData.OnPlayerLifeChanged+= StaticDataOnPlayerLifeChanged;
        StaticDataOnPlayerLifeChanged(null, null);
    }

    private void OnDestroy() {
        StaticData.OnPlayerLifeChanged+= StaticDataOnPlayerLifeChanged;
    }

    //SeLance à chaque foix que les PVs du joueur changent, elle permet de dire quelles incones de point de vie
    //doivent apparètre et les quelle doivent disparète en utilisant les Methods Ci-dessous.
    private void StaticDataOnPlayerLifeChanged(object sender, EventArgs e) {
        for (int i = 0; i < _heathPoint.Length; i++) {
            if (_heathPoint[i] == null) continue;

            if (i < StaticData.PlayerLifes) {
                ActivateLife(_heathPoint[i]);
                
            }
            else {
                DeactivateLife(_heathPoint[i]);
            }
        }
    }

    // Se Lance pour désactiver une Vie ,cette dernière c'est "LifeObject".
    private void DeactivateLife(GameObject lifeObject) {
        
        lifeObject.transform.DOScale(_endSize, _lifeTime).SetEase(_animationCurve);
        lifeObject.transform.DORotate(_endRotation, _lifeTime).SetEase(_animationCurve);
        
        //lifeObject.SetActive(false);
    }
    // Se Lance pour Activer une Vie ,cette dernière c'est "LifeObject".
    private void ActivateLife(GameObject lifeObject)
    {
        lifeObject.SetActive(true);
    }
}