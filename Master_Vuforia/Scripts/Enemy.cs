using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador; //Creamos una variable para el transform del jugador
    public LayerMask capaDelJugador; //Creamos una variable para definir la capa del jugador
    public float rangoDeAlerta; //Creamos una variable para la esfera de rango de alerta de los enmigos
    public float speed; //Variable para la velocidad
    bool estarAlerta; //Variable para cuando se atraviese el campo de alerta
    public SoundManager _soundManager; //Variable para el soundmanager

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position,rangoDeAlerta,capaDelJugador); //Con checksphere comprobamos si el jugador esta dentro del rango

        if (estarAlerta == true)
        {   
            _soundManager.seleccionAudio(10, 0.4f); //Sonido del fantasma moviendose
            //transform.LookAt(jugador);
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z); //Guardamos la posicion del jugador
            transform.LookAt(posJugador); //Con lookat nos dirigimos hacia la posicion del jugador
            transform.position = Vector3.MoveTowards(transform.position, posJugador, speed * Time.deltaTime); //Creamos el movimiento hacia la posicion del jugador
        }
    }
    private void awake(){
      _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }
    private void OnDrawGizmos() { //Con la funcion draw gizmos creamos la esfera invisible que nos mostrara el rango de alerta
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
