using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    public GameObject Bloco;
    GameManager gm;


    // -----

    // Start is called before the first frame update
    void Start(){

        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }

        if (gm.gameState == GameManager.GameState.MENU) Construir();
    
    }


  void Construir(){     

       if (gm.gameState == GameManager.GameState.MENU){
            foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        for(int i = 0; i < 9; i++){
        
            for(int j = 0; j < 5; j++){
        
                Vector3 posicao = new Vector3(-7 + 1.75f * i, 4 - 0.75f * j);
                Instantiate(Bloco, posicao, Quaternion.identity, transform);
        
            }
        }
      }
  }
}
