using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private TextMeshProUGUI textfield;
    [SerializeField] private RectTransform cardContainer;

    private List<Card> cards = new List<Card>();

    private bool animationsPaused = false;

    private float lastUpdate = 0;
    private int listUpdateCounter;
    private List<string> listUpdateItem = new List<string> { "●", "●", "○", "○" };

    void Start() {
        for (int i = 0; i < 1; i++) {
            cards.Add(Instantiate(cardPrefab, cardContainer.transform, false).GetComponent<Card>());
        }
    }

    private void Update() {
        if (Time.time - lastUpdate > 0.1f) {
            textfield.text = $"{Mathf.CeilToInt(1 / Time.deltaTime)}fps{listUpdateItem[listUpdateCounter]}";
            lastUpdate = Time.time;
            if (++listUpdateCounter >= listUpdateItem.Count) {
                listUpdateCounter = 0;
            }
        }
    }


    public void OnPointerClick(PointerEventData eventData) {
        animationsPaused = !animationsPaused;
        // DOTween.TogglePauseAll();

        foreach (var card in cards) {
            card.PauseAnimation(animationsPaused);
        }
    }
}