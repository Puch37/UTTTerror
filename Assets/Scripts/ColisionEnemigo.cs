using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionEnemigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisionamos tiene el tag "enemigo"
        if (other.CompareTag("enemigo"))
        {
            // Verificar si el objeto con el que colisionamos tiene el tag "Player"
            if (gameObject.CompareTag("Player"))
            {
                // Cargar la escena "badending"
                Debug.Log("Colisión con el enemigo detectada. Cargando la escena 'badending'...");
                SceneManager.LoadScene("badending");
            }
            else
            {
                Debug.LogWarning("¡ADVERTENCIA! Colisión detectada, pero el objeto no tiene el tag 'Player'.");
            }
        }
        else
        {
            Debug.LogWarning("¡ADVERTENCIA! Colisión detectada, pero el objeto no tiene el tag 'enemigo'.");
        }
    }
}
