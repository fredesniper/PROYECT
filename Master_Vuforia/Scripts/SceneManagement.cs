using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  //Creamos una funcion para ir al menu principal
  public void MainMenu(){

    SceneManager.LoadScene(1, LoadSceneMode.Single);

  }
  //Creamos una funcion para iniciar el juego
  public void StartGame(){

    SceneManager.LoadScene(0, LoadSceneMode.Single);

  }

  //Creamos una funcion para cerrar la app
  public void QuitGame(){

    Application.Quit();

  }
}
