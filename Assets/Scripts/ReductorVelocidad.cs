using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReductorVelocidad : MonoBehaviour
{
    public movimientojugador controladorJugador;
    private float velocidadOriginal;

    void Start()
    {
        // Guardar la velocidad original del jugador
        velocidadOriginal = controladorJugador.speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador toca el objeto, reducir su velocidad a la mitad
        if (other.gameObject == controladorJugador.gameObject)
        {
            controladorJugador.speed *= 0.2f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador deja de tocar el objeto, restaurar su velocidad original
        if (other.gameObject == controladorJugador.gameObject)
        {
            controladorJugador.speed = velocidadOriginal;
        }
    }
}
