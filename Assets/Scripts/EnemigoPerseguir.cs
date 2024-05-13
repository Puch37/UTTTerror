using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguir : MonoBehaviour

{
    public Transform jugador; //Asignar el transform del jugador en el inspector

    void Update()
    {
        //Hacer que el enemigo mire hacia el jugador
        transform.LookAt(jugador);
    }
}
