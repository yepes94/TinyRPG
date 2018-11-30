using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Completed
{
	//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
    public class Enemy : MonoBehaviour
	{
        public int speed = 4;
        public int direccionAnterior;
        public int playerDamage; 							//The amount of health points to subtract from the player when attacking.
		//public AudioClip attackSound1;						//First of two audio clips to play when attacking the player.
		//public AudioClip attackSound2;						//Second of two audio clips to play when attacking the player.
        private Rigidbody2D enemyRB;
		
		private Animator animator;							//Variable of type Animator to store a reference to the enemy's Animator component.
		private Transform target;                           //Transform to attempt to move toward each turn.
                                                            //private bool skipMove;								//Boolean to determine whether or not enemy should skip a turn or move this turn.
        private Vector2 move;
        private bool moveUp = true;


        private void Update(){
            MoveEnemy();

        }

		//Start overrides the virtual Start function of the base class.
		protected void Start ()
		{
            //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
            //This allows the GameManager to issue movement commands.
            //GameManager.instance.AddEnemyToList (this);

            enemyRB = GetComponent<Rigidbody2D>();

            //Get and store a reference to the attached Animator component.
            animator = GetComponent<Animator> ();
			
			//Find the Player GameObject using it's tag and store a reference to its transform component.
			target = GameObject.FindGameObjectWithTag ("Player").transform;
			
			//Call the start function of our base class MovingObject.
			//base.Start ();
		}
		

		//MoveEnemy is called by the GameManger each turn to tell each Enemy to try to move towards the player.
		public void MoveEnemy ()
		{
            if (moveUp)
                move = new Vector2 (0, 1);
            else
                move = new Vector2 (0, -1);
             

		}

        private void FixedUpdate()
        {
                enemyRB.MovePosition(enemyRB.position + move * speed * Time.deltaTime);
                //enemyRB.MovePosition(enemyRB.position + direccionAnterior * speed * Time.deltaTime);

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D");
            if (moveUp)
                moveUp = false;
            else
                moveUp = true;
        }

    }
}


/*
Crear BBDD
Crear Taula usuaris
Amb estructura donada, insertar una fila a la BBDD
Ha de tenir clau primària, ha de ser autoincremental

*/