using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour , IPointerClickHandler{
    public GameObject cardPrefab;
    private List<Card> cards = new List<Card>();
    private bool animationsPaused = false;
    void Start() {
        for (int i = 0; i < 120; i++) {
            cards.Add(Instantiate(cardPrefab, transform, false).GetComponent<Card>()); 
        }
    }


    public void OnPointerClick(PointerEventData eventData) {
        animationsPaused = !animationsPaused;
        DOTween.TogglePauseAll();

        foreach (var card in cards) {
            card.PauseAnimation(animationsPaused);
        }
        
    }
}