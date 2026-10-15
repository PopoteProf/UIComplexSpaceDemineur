using UnityEngine;

public class WinTriggerZone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StaticData.DoPlayerWin();
            Debug.Log("Win");
        }
    }
}