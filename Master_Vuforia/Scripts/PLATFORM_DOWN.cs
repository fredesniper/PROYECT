using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATFORM_DOWN : MonoBehaviour
{
    float momInicio =  float.MaxValue;
    float tiempoHastaEx =  5f;
    Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update() {
        if (Time.time > momInicio + tiempoHastaEx)
        {
            enableConstrains();
            momInicio = float.MaxValue;
            Debug.Log("Se activa la gravedad");
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
    
}
