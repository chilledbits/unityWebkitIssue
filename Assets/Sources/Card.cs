using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public List<Sprite> assets;
    [SerializeField] private GameObject frontSide;
    [SerializeField] private GameObject backSide;
    private static int counter = 0;


    private Animator animator;
    private bool isConcealed = false;

    // Start is called before the first frame update
    void Start() {
        // different sprite >> to increase draw-calls
        frontSide.GetComponent<Image>().sprite = assets[counter];
        backSide.SetActive(false);
        
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", Random.Range(0.5f, 2));

        if (++counter >= assets.Count) {
            counter = 0;
        }

        Move();
    }

    public void LastSibling() {
        isConcealed = !isConcealed;
        backSide.SetActive(isConcealed);
        frontSide.SetActive(!isConcealed);

        transform.SetAsLastSibling();
    }

    private void Move() {
        var duration = Random.Range(2.5f, 5);
        transform.DOLocalMove(GetRandomPosition(), duration).OnComplete(Move);
        transform.DOLocalRotate(new Vector3(0, 0, Random.Range(-180, 180)), duration);
    }

    private Vector2 GetRandomPosition() {
        return new Vector2(Random.Range(0, Screen.width) - Screen.width / 2, Random.Range(0, Screen.height) - Screen.height / 2);
    }

    public void PauseAnimation(bool animationsPaused) {
        animator.enabled = !animationsPaused;
    }
}