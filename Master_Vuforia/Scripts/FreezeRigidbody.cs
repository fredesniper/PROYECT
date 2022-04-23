using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //Requerimos el rigibody si lo eliminamos en el editor se añadira auto

public class FreezeRigidbody : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //Guardamos el rigibody en la variable
    }

    //Creamos una funcion para congelar el riggidboy de la bola cuando no detecte el target
    public void EnableRigidbody(bool enable){ //Esta habilitado el rigibody si es si None si es no FreezeALL

        _rigidbody.constraints = enable ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
    }
}
