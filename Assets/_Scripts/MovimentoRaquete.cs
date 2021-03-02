using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    [Range(1, 10)]
    public float v;

    private float velocidade;
    private bool isOnWall;

    float inputX;
    float oldImputX;

    GameManager gm;

    // Start is called before the first frame update
    void Start(){
        gm = GameManager.GetInstance();
        
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        if (gm.gameState != GameManager.GameState.GAME) return; 

        inputX = Input.GetAxis("Horizontal");
        velocidade = v;

        if (isOnWall){

            if (inputX > 0 && oldImputX < 0 || inputX < 0 && oldImputX > 0){
                // Debug.Log(isOnWall);
                isOnWall = false;
            }

            velocidade = 0f;
        }

        transform.position += new Vector3(inputX,0,0) * Time.deltaTime * velocidade;


    
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "bounderies"){
            isOnWall = true;
            oldImputX = inputX;
        }
    }

}
