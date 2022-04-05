using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //Requerimos el rigibody si lo eliminamos en el editor se añadira auto
public class Player : MonoBehaviour
{
    //Variables las privadas empiezan por _xxxx 
    private Rigidbody _rigidbody; //Variable para el rigidbody
    private GameManager _gameManager; //Variable para acceder al GameManager

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //Guardamos el rigibody en la variable
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//Guardamos el GameManager en la variable
        
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
    }
    //Creamos una funcion para detectar la colision contra los coleccionables (Tag-Collectable)
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectable")){
            Destroy(other.gameObject);
            _gameManager.actualizarContador(1);
        }
    }
    //Creamos una funcion para detectar que el jugador esta fuera del tablero
    private void playerDown(){
        if(transform.position.y <= -4 | transform.position.y >= 4){
            _gameManager.GameOver();
            Destroy(this.gameObject);
        }
    }
}
