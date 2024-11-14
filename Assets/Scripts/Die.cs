using System.Collections;
using UnityEngine;

public class Die : MonoBehaviour {

    private Rigidbody rb;
    public float maxTorque = 20.0f;
    public float minTorque = 5.0f;
    public float jumpForceMin = 10.0f;
    public float jumpForceMax = 10.0f;
    public bool grounded = true;
    // private bool diceIsProper = true;


    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

        // rb.AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
        // rb.AddTorque(new Vector3(Random.Range(minTorque, maxTorque), 0.0f, 0.0f), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {

            // Roll the die
            RollDie();
        }

        // Restrict die's Y-axis
        if (transform.position.y > 0.9f) {

            transform.position = new Vector3(transform.position.x, 0.9f, transform.position.z);
            rb.velocity = Vector3.zero;
        }
    }

    private void RollDie() {

        grounded = false;
        // diceIsProper = false;
        StartCoroutine("FixDie");
        UIManager.Instance.UpdateDieText("");

        // Add a random jump force
        rb.AddForce(Random.Range(jumpForceMin, jumpForceMax) * Vector3.up, ForceMode.Impulse);

        // Calculate a random torqueVector
        Vector3 torqueVector = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque));

        rb.AddTorque(torqueVector);
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.CompareTag("Ground")) {

            grounded = true;
        }
    }

    public float GetDieSpeed() {
        return rb.velocity.magnitude;
    }

    IEnumerator FixDie() {

        yield return new WaitForSeconds(2.0f);
        Debug.Log("Fixing die...");
        rb.AddTorque(new Vector3(minTorque, minTorque, minTorque));
    }

    public void CancelFixDie() {

        StopAllCoroutines();
    }
}
