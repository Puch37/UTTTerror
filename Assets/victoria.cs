using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Este método se llama cuando hay una colisión con el objeto
        // Verificar si el objeto que colisionó tiene el tag "enemigo"
        if (other.CompareTag("enemigo"))
        {
            // Cargar la escena "goodending"
            SceneManager.LoadScene("goodending");
        }
    }
}
