using UnityEngine;
using UnityEngine.SceneManagement;

public class ColeccionableController : MonoBehaviour
{
    public int objetivoColeccionables = 10;  // Puedes ajustar este valor según sea necesario
    private int contadorColeccionables = 0;

    private void Start()
    {
        // Mover el objeto a un lugar aleatorio sobre un objeto con el tag "piso"
        MoverAColeccionable();
    }

    private void Update()
    {
        // Si presionas la tecla "e" y colisionas con el objeto, incrementa el contador
        if (Input.GetKeyDown(KeyCode.E) && EstaColisionando())
        {
            contadorColeccionables++;

            // Verifica si se ha alcanzado el objetivo
            if (contadorColeccionables >= objetivoColeccionables)
            {
                CargarGoodEnding();
            }
            else
            {
                // Si no se ha alcanzado el objetivo, mueve el objeto a otro lugar aleatorio
                MoverAColeccionable();
            }
        }
    }

    private bool EstaColisionando()
    {
        // Verifica si hay al menos una colisión física con el ratón
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject;
    }

    private void MoverAColeccionable()
    {
        GameObject[] pisos = GameObject.FindGameObjectsWithTag("piso");

        if (pisos.Length > 0)
        {
            GameObject pisoAleatorio = pisos[Random.Range(0, pisos.Length)];

            // Obtener la posición del jugador
            Vector3 posicionJugador = Camera.main.transform.position;

            // Establecer la nueva posición del objeto al mismo nivel del jugador
            transform.position = new Vector3(pisoAleatorio.transform.position.x, posicionJugador.y, pisoAleatorio.transform.position.z);

            Debug.Log("Objeto movido a un lugar aleatorio al mismo nivel del jugador.");
        }
    }

    private void CargarGoodEnding()
    {
        SceneManager.LoadScene("goodending");
        Debug.Log("Escena 'goodending' cargada.");
    }
}
