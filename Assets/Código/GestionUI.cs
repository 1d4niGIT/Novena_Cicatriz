using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionUI : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void BotonPrueba()
    {
        Debug.Log("¡Click!");
    }

    public void IrAEscena(int EscenaIndice)
    {
        SceneManager.LoadScene(EscenaIndice);
    }
}
