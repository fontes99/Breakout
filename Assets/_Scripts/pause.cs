using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    GameManager gm;
    
    // Start is called before the first frame update
    private void OnEnable(){

        gm = GameManager.GetInstance();
        
    }

    // Update is called once per frame
    public void Retomar(){

        gm.ChangeState(GameManager.GameState.GAME);
        
    }

    public void Recomecar(){

        gm.ChangeState(GameManager.GameState.MENU);

    }
}
