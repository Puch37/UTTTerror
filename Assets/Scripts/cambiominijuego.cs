using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string nombreEscena; //Asignar el nombre de la escena en el inspector

    void OnTriggerEnter(Collider other)
    {
        //Comprobar si el objeto con el que colisionas tiene el tag "enemigo"
        if (other.gameObject.CompareTag("enemigo"))
        {
            //Mostrar un mensaje en la consola de que se detectó el disparador
            Debug.Log("Se detectó el disparador con el enemigo");

            //Cambiar a la escena con el nombre asignado en modo single (reemplaza la escena actual)
            SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);

            //Mostrar un mensaje en la consola de que se cargó la escena
            Debug.Log("Se cargó la escena " + nombreEscena);
        }
    }
}
