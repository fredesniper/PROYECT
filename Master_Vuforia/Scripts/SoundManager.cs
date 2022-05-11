using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _audios; //Creamos un array para guardar los sonidos del juego
    private AudioSource _controlAudio; //Creamos el audiosource
    //Obtenemos el audiosource
    private void Awake() {
        _controlAudio = GetComponent<AudioSource>();   
    }
    //Creamos una funcion que abra los audios del array
    public void seleccionAudio(int indice, float volumen){
        _controlAudio.PlayOneShot(_audios[indice], volumen);
    }
}
