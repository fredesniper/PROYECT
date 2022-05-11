using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public int actualScene;
  public SoundManager _soundManager; //Variable para el soundmanager 
  public int _sceneToLoad;
  //Creamos una funcion para ir al menu principal
  public void MainMenu(){

    SceneManager.LoadScene(0, LoadSceneMode.Single);

  }
  //Creamos una funcion para iniciar el juego
  public void StartGame(){

    SceneManager.LoadScene(actualScene, LoadSceneMode.Single);
  }

  //Creamos una funcion para cerrar la app
  public void QuitGame(){

    Application.Quit();

  }
  //Crear una funcion para superar el nivel
  public void nextLevel(int level){
    SceneManager.LoadScene(level,LoadSceneMode.Single);
  }
   //Crear una funcion para superar el nivel
  public void sceneLoad(int _sceneToLoad){
    SceneManager.LoadScene(_sceneToLoad,LoadSceneMode.Single);
  }
  //Creamos una variable para activar el soundmanager
  private void awake(){
      _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
   }
}
