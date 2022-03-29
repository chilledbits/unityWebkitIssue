using DG.Tweening;
using UnityEngine;

public class Main : MonoBehaviour {
    public GameObject cardPrefab;


    void Start() {
        var alt = true;
        for (int i = 0; i < 120; i++) {
            var card = Instantiate(cardPrefab, transform, false);
        }
    }
}