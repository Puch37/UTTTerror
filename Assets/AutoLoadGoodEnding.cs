using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadGoodEnding : MonoBehaviour
{
    private void Start()
    {
        // Llamada al método que verifica si no hay objetos con el tag "CanvasQuiz" dentro del objeto actual
        CheckNoCanvasQuizzes();
    }

    private void CheckNoCanvasQuizzes()
    {
        // Buscar objetos con el tag "CanvasQuiz" dentro de la jerarquía de este objeto
        GameObject canvasQuizzes = FindObjectWithTagInHierarchy(transform, "CanvasQuiz");

        // Verificar si no se encontraron objetos con el tag "CanvasQuiz"
        if (canvasQuizzes == null)
        {
            // Cargar la escena "goodending"
            SceneManager.LoadScene("goodending");
            return; // Agregamos un return para salir del método y evitar más ejecución
        }

        // Continuar con cualquier otra lógica aquí
    }

    private GameObject FindObjectWithTagInHierarchy(Transform parent, string tag)
    {
        // Buscar objetos con el tag en la jerarquía de este objeto
        Transform childTransform = parent.Find(tag);
        
        // Si no se encuentra en este nivel, buscar en los hijos recursivamente
        if (childTransform == null)
        {
            foreach (Transform child in parent)
            {
                GameObject childObject = FindObjectWithTagInHierarchy(child, tag);
                if (childObject != null)
                {
                    return childObject;
                }
            }
        }

        return (childTransform != null) ? childTransform.gameObject : null;
    }
}
