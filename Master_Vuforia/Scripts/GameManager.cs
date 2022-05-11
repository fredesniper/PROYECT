using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wellDone; //Creamos una variable para el nivel completado
    public GameObject gameOver; //Creamos una variable para el texto de puntos
    public GameObject joystick; //Creamos una variable para el boton joystick
    public GameObject jumpBtn; //Creamos una variable para el boton de salto
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
    public SoundManager _soundManager; //Variable para el soundmanager 
    public int _nextLevel; //Variable para el siguiente nivel
    //ATENCION EN CADA NIVEL SE DEBE CAMBIAR ESTE NUMERO POR EL DEL SIGUIENTE NIVEL
    
    // Start is called before the first frame update
    void Start()
    {
        _contador = 0;
        actualizarContador(0);
    }

    private void awake(){
      _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }

    // Update is called once per frame
    void Update()
    {   
        if(tiempoStart){

           tiempoRestante -= Time.deltaTime;
            if(tiempoRestante < 1){
                GameOver();
                player.SetActive(false);//El jugador es desactivado
                tiempoStart = false;
            }
            int tempMin = Mathf.FloorToInt(tiempoRestante / 60);
            int tempSeg = Mathf.FloorToInt(tiempoRestante % 60);
            tiempoCanvas.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }

        if(_contador >= 10){ //Si conseguimos los 10 diamantes el nivel es superado activamos el texto
            wellDone.SetActive(true);
            timeManager.SetActive(false);
            _soundManager.seleccionAudio(8, 0.5f); //Sonido well done
            StartCoroutine(waitForChange(5f)); //Activamos la funcion con retardo para el cambio de nivel
            //CAMBIAMOS AL SIGUIENTE NIVEL NEXT LEVEL FUNCTION
        }
    }
    //Funcion para actualizar el contador
    public void actualizarContador(int puntosAsumar){
        _contador += puntosAsumar;
        puntosCanvas.text = " " + _contador;    
    }
    //Funcion gameOver
    public void GameOver(){
        _soundManager.seleccionAudio(3, 0.5f);//Seleccionamos el sonido de gameover

        if(player != null ){ //Comprobamos que el jugador es destruido y activamos los objetos
            gameOver.SetActive(true);
            startBtn.SetActive(true);
            menuBtn.SetActive(true);
            joystick.SetActive(false);
            jumpBtn.SetActive(false);
            timeManager.SetActive(false);
        }else{
            gameOver.SetActive(false);
            startBtn.SetActive(false);
            menuBtn.SetActive(false);
            timeManager.SetActive(true);
            joystick.SetActive(true);
            jumpBtn.SetActive(true);
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
        SceneManager.GetComponent<SceneManagement>().nextLevel(_nextLevel); //LLamamos a la funcion que cambia de nivel
    }
}
