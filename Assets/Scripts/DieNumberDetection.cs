using UnityEngine;

public class DieNumberDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Ground")) {

            UIManager.Instance.UpdateDieText(gameObject.name);
        }
    }
}
