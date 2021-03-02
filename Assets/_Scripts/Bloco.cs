using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("exists", true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        anim.SetBool("exists", false);
        StartCoroutine(destroy_block());

    
    }

    IEnumerator destroy_block(){
        if ( anim.GetBool("exists") == false ){

            // GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.4f);
            Destroy(gameObject);

        }

        yield return null;

    }

}
