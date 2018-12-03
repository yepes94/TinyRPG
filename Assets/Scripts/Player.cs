using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody2D playerRB;
    private Animator anim;
    Vector2 mov;
    Vector2 direccionAnterior;
    public Joystick joystick;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {

        MoverPersonaje();
	}

    private void FixedUpdate()
    {
        if (Mathf.Abs(mov.x) != Mathf.Abs(mov.y))
            playerRB.MovePosition(playerRB.position + mov * speed * Time.deltaTime);
        else if (mov.sqrMagnitude != 0)
            playerRB.MovePosition(playerRB.position + direccionAnterior * speed * Time.deltaTime);

    }

    public void MoverPersonaje()
    {
        /*
        mov = new Vector2( 
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        */
        mov = new Vector2(
            Mathf.Round(joystick.Horizontal),
            Mathf.Round(joystick.Vertical) 
            );
        


        if (Mathf.Abs(mov.x) != Mathf.Abs(mov.y) && Input.anyKey)
        {
            direccionAnterior = mov;
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        }
        else if (mov.sqrMagnitude != 0)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);
            
    }
    
        
}
