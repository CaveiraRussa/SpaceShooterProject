using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float scrollSpeed; // velocidade que o Background vai se mover
    public float tileSizeY; // tamanho do background, toda vez que atinge esse tamanho ele reseta
    
    private Vector2 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position; //seta a posição inicial do mapa
       
    }
	
	// Update is called once per frame
	void Update () {
       
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY); 
            transform.position = startPosition + Vector2.down * newPosition;  
        
       
       
	}

    

}
