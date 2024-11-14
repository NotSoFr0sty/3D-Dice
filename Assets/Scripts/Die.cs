using UnityEngine;

public class Die : MonoBehaviour {

    private Rigidbody rb;
    public float maxTorque = 20.0f;
    public float minTorque = 5.0f;
    public float jumpForceMin = 10.0f;
    public float jumpForceMax = 10.0f;


    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

        // rb.AddTorque(new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque)));
        // rb.AddTorque(new Vector3(Random.Range(minTorque, maxTorque), 0.0f, 0.0f), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            // Roll the die
            RollDie();
        }
    }

    private void RollDie() {

        rb.AddForce(Random.Range(jumpForceMin, jumpForceMax) * Vector3.up, ForceMode.Impulse);

        // Calculate a random torqueVector
        Vector3 torqueVector = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque));

        rb.AddTorque(torqueVector);
    }
}
