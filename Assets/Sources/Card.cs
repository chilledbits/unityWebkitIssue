using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public List<Sprite> assets;
    private static int counter = 0;
    
    // Start is called before the first frame update
    void Start() {
        // different sprite >> to increase draw-calls
        GetComponent<Image>().sprite = assets[counter];
        GetComponent<Animator>().SetFloat("speed", Random.Range(0.5f, 2));
        
        if (++counter >= assets.Count) {
            counter = 0;
        }
        
        Move();
    }

    public void LastSibling() {
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
}
