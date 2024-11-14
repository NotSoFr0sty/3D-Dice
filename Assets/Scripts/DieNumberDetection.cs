using UnityEngine;

public class DieNumberDetection : MonoBehaviour {

    private Die die;

    private void Start() {

        die = FindAnyObjectByType<Die>();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Ground")) {

            UIManager.Instance.UpdateDieText(gameObject.name);
            die.CancelFixDie();
        }
    }
}
