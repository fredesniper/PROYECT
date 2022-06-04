using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATFORM_PLACED : MonoBehaviour
{
    float momInicio =  float.MaxValue;
    float tiempoHastaEx =  5f;
    float tiempoHastaEx2 =  7f;
    Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
     void Update() {
        if (Time.time > momInicio + tiempoHastaEx)
        {
            enableConstrains();
            momInicio = float.MaxValue;
            
            Debug.Log("Se activa la gravedad");//En 5 segundos
        }

        if (Time.time > momInicio + tiempoHastaEx2)
        { 
            enableKinematic();
           momInicio = float.MaxValue;
            Debug.Log("Se activa el kinematic"); //En 7 segundos
        }
    }

     //Creamos una funcion para detectar la colision del jugador contra las plataformas
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")){
            Debug.Log("El jugador ha colisionado contra una plataforma");
            momInicio = Time.time;
            Debug.Log(Time.time);
        }
    }

    private void enableConstrains(){
        _rigidbody.useGravity = enabled; //Activamos la gravedad
        _rigidbody.isKinematic = false; //Desactivamos isKinematic
    }

    private void enableKinematic(){
        _rigidbody.isKinematic = true; //Con esta funcion activamos isKinematic   
        _rigidbody.useGravity = false;
    }
}
