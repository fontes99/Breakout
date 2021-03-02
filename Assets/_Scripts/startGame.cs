using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{

    GameManager gm;

    // Start is called before the first frame update
    public void OnEnable()
    {
        gm = GameManager.GetInstance();    
    }

    // Update is called once per frame
    public void Comecar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
