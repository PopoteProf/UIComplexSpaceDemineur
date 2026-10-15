using System;
using DG.Tweening;
using UnityEngine;

public class UIHeathPoint : MonoBehaviour {
    [SerializeField] private GameObject[] _heathPoint;

    [SerializeField] private float _deactivationAnimationTime = 0.5f;
    [SerializeField] private Vector3 _deactivationScale = Vector3.zero;
    [SerializeField] private Vector3 _deactivationRotation = Vector3.zero;
    [SerializeField] private AnimationCurve _deactivationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    
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
        lifeObject.transform.DOScale(_deactivationScale, _deactivationAnimationTime).SetEase(_deactivationCurve);
        lifeObject.transform.DORotate(_deactivationRotation, _deactivationAnimationTime);
        // lifeObject.SetActive(false);
    }
    // Se Lance pour Activer une Vie ,cette dernière c'est "LifeObject".
    private void ActivateLife(GameObject lifeObject)
    {
        lifeObject.SetActive(true);
    }
}