using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver; //Creamos una variable para el texto de puntos
    public GameObject startBtn; //Creamos una variable para el boton start
    public GameObject menuBtn; //Creamos una variable para el boton menu
    public TextMeshProUGUI puntosCanvas; //Creamos una variable para el texto de puntos
    public TextMeshProUGUI tiempoCanvas; //Creamos una variable para el texto del temporizador
    public int Minutos, Segundos; //Creamos las variables para introducir el tiempo
    private int _contador; //Creamos una variable contador
    private float tiempoRestante; //Variable para el tiempo restante
    private bool tiempoStart; //Variable para comenzar el tiempo
    public GameObject player; //Creamos una variaable para el jugador
    

    // Start is called before the first frame update
    void Start()
    {
        _contador = 0;
        actualizarContador(0);
        timeStart();
    }

    // Update is called once per frame
    void Update()
    {   
        if(tiempoStart){

           tiempoRestante -= Time.deltaTime;
            if(tiempoRestante < 1){
                GameOver();
                tiempoStart = false;
            }
            int tempMin = Mathf.FloorToInt(tiempoRestante / 60);
            int tempSeg = Mathf.FloorToInt(tiempoRestante % 60);
            tiempoCanvas.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
    //Funcion para actualizar el contador
    public void actualizarContador(int puntosAsumar){
        _contador += puntosAsumar;
        puntosCanvas.text = " " + _contador;    
    }
    //Funcion gameOver
    public void GameOver(){
        if(player != null ){ //Comprobamos que el jugador es destruido y activamos los objetos
            gameOver.SetActive(true);
            startBtn.SetActive(true);
            menuBtn.SetActive(true);
        }else{
            gameOver.SetActive(false);
            startBtn.SetActive(false);
            menuBtn.SetActive(false);
        }
    }

    //Funcion para controlar el tiempo
    private void timeStart(){
        tiempoStart = true;
        tiempoRestante = (Minutos * 60) + Segundos;
    }


    //Funcion start game (Inicia el juego y desactiva el menu)

    //Funcion cambio de nivel (Permite elegir nivel superado en el menu)
}
