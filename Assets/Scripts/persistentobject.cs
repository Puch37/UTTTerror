using UnityEngine;

public class persistentobject : MonoBehaviour
{
    // Instancia estática del objeto persistente
    private static persistentobject _instance;

    // Propiedad para acceder a la instancia desde otros scripts
    public static persistentobject Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        // Asegúrate de que solo haya una instancia del objeto persistente
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
