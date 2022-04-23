using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wellDone; //Creamos una variable para el nivel completado
    public GameObject gameOver; //Creamos una variable para el texto de puntos
    public GameObject timeManager; //Creamos una variable para el administrador de tiempo
    public GameObject startBtn; //Creamos una variable para el boton start
    public GameObject menuBtn; //Creamos una variable para el boton menu
    public TextMeshProUGUI puntosCanvas; //Creamos una variable para el texto de puntos
    public TextMeshProUGUI tiempoCanvas; //Creamos una variable para el texto del temporizador
    public int Minutos, Segundos; //Creamos las variables para introducir el tiempo
    private int _contador; //Creamos una variable contador
    private float tiempoRestante; //Variable para el tiempo restante
    private bool tiempoStart; //Variable para comenzar el tiempo
    public GameObject player; //Creamos una variaable para el jugador
    public GameObject SceneManager; //Creamos una variable para el sceneManager
    
    // Start is called before the first frame update
    void Start()
    {
        _contador = 0;
        actualizarContador(0);
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

        if(_contador >= 7){ //Si conseguimos los 10 diamantes el nivel es superado activamos el texto
            wellDone.SetActive(true);
            timeManager.SetActive(false);
            StartCoroutine(waitForChange(5f)); //Activamos la funcion con retardo para el cambio de nivel
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
            timeManager.SetActive(false);
        }else{
            gameOver.SetActive(false);
            startBtn.SetActive(false);
            menuBtn.SetActive(false);
            timeManager.SetActive(true);
        }
    }

    //Funcion para controlar el tiempo
    public void timeStart(){
        tiempoStart = true;
        tiempoRestante = (Minutos * 60) + Segundos;
    }
    //Funcion DELAY cambio de nivel (Permite elegir nivel superado en el menu)
    IEnumerator waitForChange(float time) {
        yield return new WaitForSeconds(time); //Esperamos el tiempo necesario
        SceneManager.GetComponent<SceneManagement>().nextLevel(0); //LLamamos a la funcion que cambia de nivel
    }
}
