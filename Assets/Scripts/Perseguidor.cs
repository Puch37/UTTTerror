using UnityEngine;

public class Perseguidor : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 5.0f;
    public float distanciaDePersecucion = 10.0f;
    private Vector3 posicionInicial;

    void Start()
    {
        // Al inicio, guarda la posición inicial del enemigo.
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador.
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está dentro de la distancia de persecución, persigue al jugador.
        if (distanciaAlJugador <= distanciaDePersecucion)
        {
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();
            transform.position += direccion * velocidad * Time.deltaTime;
        }
        else
        {
            // Si el jugador está fuera de la distancia de persecución, vuelve a la posición inicial.
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.deltaTime);
        }
    }
}
