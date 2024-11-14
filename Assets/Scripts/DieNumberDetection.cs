using UnityEngine;

public class DieNumberDetection : MonoBehaviour {

    private Die die;

    private void Start() {

        die = FindAnyObjectByType<Die>();
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Ground") && (die.GetDieSpeed() <= 0.5)) {

            UIManager.Instance.UpdateDieText(gameObject.name);
            die.CancelFixDie();
        }
    }
}
