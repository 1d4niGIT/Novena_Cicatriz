using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image RellenoVida;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ActualizarBarra(float VidaActual, float VidaMaxima)
    {
        RellenoVida.fillAmount = VidaActual / VidaMaxima;
    }
}
