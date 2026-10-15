using TMPro;
using UnityEngine;

public class UICounter : MonoBehaviour {
    [SerializeField] private TMP_Text _txtDeactivadedCount;
    [SerializeField] private TMP_Text _txtExplodededCount;

    public void Start() {
        StaticData.OnMineDeactivatedCountChange += StaticDataOnMineDeactivatedCountChange;
        StaticData.OnMineExplodeCountChange+= StaticDataOnMineExplodeCountChange;
    }

    private void OnDestroy()
    {
        StaticData.OnMineDeactivatedCountChange -= StaticDataOnMineDeactivatedCountChange;
        StaticData.OnMineExplodeCountChange-= StaticDataOnMineExplodeCountChange;
    }

    // S'active à chaquie fois qu'une mine explose et fait passer le nombre qui on exploser dans le paramètre "explosionCount". 
    private void StaticDataOnMineExplodeCountChange(object sender, int explosionCount) {
        _txtExplodededCount.text = explosionCount.ToString();
    }

    //S'active à chaque fois qu'une mine est dés'activer, et fait passe le nombre désactiver dans le paramètre "deactivaterCount"
    private void StaticDataOnMineDeactivatedCountChange(object sender, int deactivaterCount) {
        _txtDeactivadedCount.text = deactivaterCount.ToString();
    }
}