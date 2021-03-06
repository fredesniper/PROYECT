using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //Requerimos el rigibody si lo eliminamos en el editor se añadira auto
public class Player : MonoBehaviour
{
    //Variables las privadas empiezan por _xxxx 
    private Rigidbody _rigidbody; //Variable para el rigidbody
    private GameManager _gameManager; //Variable para acceder al GameManager
    public SoundManager _soundManager; //Variable para el soundmanager 

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //Guardamos el rigibody en la variable
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//Guardamos el GameManager en la variable   
    }
    private void awake(){
      _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }

    void Update() {
        playerDown();
    }
    
    
    //Creamos una funcion para congelar el riggidboy de la bola cuando no detecte el target
    public void EnableRigidbody(bool enable){ //Esta habilitado el rigibody si es si None si es no FreezeALL

        _rigidbody.constraints = enable ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
    }

    //Creamos una funcion para detectar la colision del jugador contra los obstaculos (Tag-Obstacle)
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("El jugador ha colisionado contra un obstaculo");
            Destroy(this.gameObject);//Destruimos al jugador
            _gameManager.GameOver();//Ejecutamos la funcion fin del juego
        }

         if (collision.gameObject.CompareTag("Scene")) //Si colisionamos con un enemigo
        {
           _soundManager.seleccionAudio(2, 0.5f); //Audio de la madera
           Debug.Log("El jugador a tocado madera");
        }
    }
    //Creamos una funcion para detectar la colision contra los coleccionables (Tag-Collectable)
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectable")){
            Destroy(other.gameObject);
            _gameManager.actualizarContador(1);
            _soundManager.seleccionAudio(1, 0.5f); //Activamos sonido de los collectable
        }

        if(other.gameObject.CompareTag("SpecialObject")){
            Destroy(other.gameObject);
            //Llamar funcion nuevo special object encontrado
            _soundManager.seleccionAudio(4, 0.5f); //Activamos sonido de los collectable
        }

         if (other.CompareTag("Enemy")) //Si colisionamos con un enemigo
        {
            _soundManager.seleccionAudio(0, 0.5f);//Risa de fantasma
            Destroy(this.gameObject);
            _gameManager.GameOver();//Ejecutamos la funcion fin del juego
        }
    }

    //Creamos una funcion para detectar que el jugador esta fuera del tablero
    private void playerDown(){
        if(transform.position.y <= -4 | transform.position.y >= 4){
            _gameManager.GameOver();
            Destroy(this.gameObject);
            Debug.Log("Player is dead");
        }
    }
}
