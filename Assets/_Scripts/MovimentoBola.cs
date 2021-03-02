using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{

    [Range(1, 15)]
    public float velocidade = 5.0f;

    private Vector3 direcao;

    GameManager gm;


    // ----

    void RandBallMovment(){

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;

    }

    // Start is called before the first frame update
    void Start(){

        RandBallMovment();
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update(){

        if (gm.gameState == GameManager.GameState.MENU) Reset();
        if (gm.gameState != GameManager.GameState.GAME) return;

        transform.position += direcao * Time.deltaTime * velocidade;

    }

    void OnTriggerEnter2D(Collider2D col){


        if (col.tag == "boundUP"){
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        
        else if (col.tag == "bounderies"){
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        
        else if (col.tag == "bloco"){

            
            Vector3 cp = col.ClosestPoint(transform.position);
            Vector3 rel_position = transform.position - cp;
        
            if (Mathf.Abs(rel_position.y) > 0.1) direcao = new Vector3(direcao.x, -direcao.y);
            else direcao = new Vector3(-direcao.x, direcao.y);
        
            // Debug.Log($"cp: {cp} | rel: {rel_position.normalized}");
        
            gm.pontos++;

            sound_behavior.PlaySound("log_break");
        
        }
        
        else if (col.tag == "Player"){
            

            RandBallMovment();
        }
        
        else {
            gm.vidas--;
            Reset();
            sound_behavior.PlaySound("dmg");

            // direcao = new Vector3(0, 0).normalized;
        }

    }

    private void Reset(){
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 1.5f, 0);

       RandBallMovment();

       if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME){
           gm.ChangeState(GameManager.GameState.ENDGAME);
       }
   }

}
