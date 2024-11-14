using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance { get; private set; }
    [SerializeField] private TMP_Text _dieText;

    private void Awake() {

        Instance = this;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateDieText(String dieText) {

        _dieText.text = dieText;
    }
}
