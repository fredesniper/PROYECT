
using UnityEngine;

public class InputController : MonoBehaviour
{
   public SoundManager _soundManager; //Variable para el soundmanager 
   public Joystick joystickMove; //Variable para incluir el joystick
   public Rigidbody rb; //Variable para incluir el rigibody del jugador
   public float speed = 10f;
   public bool canJump;
   public float speedJump = 20f; //Creamos las variables de velocidad para el salto y el movimiento

   //Variables de fuerza
    public float maxForce;
    public float minForce;
    public Vector3 forceDirection;

   private void awake(){
      _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }
    //Creamos una variable para controlar el movimiento mediante el rigibody
   void Move(){
       rb.velocity = new Vector3(joystickMove.Horizontal * speed + Input.GetAxis("Horizontal"),rb.velocity.y, joystickMove.Vertical * speed + Input.GetAxis("Vertical"));
   }
   //Creamos una funcion para añadir fuerzas al rigibody

    public void addForce(){
        float forceMagnitude = Random.Range(minForce, maxForce);

        Vector3 force = Vector3.Normalize(forceDirection) * forceMagnitude;

        rb.AddForce(force);
    }
   //Creamos una funcion para el salto
   public void Jump(){
       if(canJump == true){
            rb.velocity +=Vector3.up * speedJump;
            _soundManager.seleccionAudio(9, 0.3f); //Seleccionamos la pista de audio
       }
   }
   //Creamos la variable update
   private void Update() {
       Move();
   }
}
