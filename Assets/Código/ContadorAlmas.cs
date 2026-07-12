using UnityEngine;
using UnityEngine.UI;

public class ContadorAlmas : MonoBehaviour
{
    public Image IconoAlmas;      
    public Sprite Sprite1Alma;     
    public Sprite Sprite2Almas;    
    public Sprite Sprite3Almas;    
    public int AlmasSalvadas = 0;
    public int MaximoAlmas = 3;
    void Start()
    {
        Debug.Log("ContadorAlmas Start() ejecutado");
        ActualizarIcono();
    }

    void Update()
    {
        
    }

    public void AgregarAlma()
    {
        Debug.Log("AgregarAlma() llamado. AlmasGuardadas antes: " + AlmasSalvadas);
        if (AlmasSalvadas < MaximoAlmas)
        {
            AlmasSalvadas++;
            Debug.Log("AlmasGuardadas ahora: " + AlmasSalvadas);
            ActualizarIcono();
        }
        else
        {
            {
                Debug.Log("Ya está en el máximo, no se suma más");
            }
        }
    }

    private void ActualizarIcono()
    {
        Debug.Log("ActualizarIcono() ejecutado con AlmasGuardadas = " + AlmasSalvadas);
        switch (AlmasSalvadas)
        {
            case 0:

                IconoAlmas.enabled = false;
                break;

            case 1:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite1Alma;
                Debug.Log("Asignando Sprite1Alma: " + (Sprite1Alma != null));
                break;

            case 2:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite2Almas;
                Debug.Log("Asignando Sprite2Almas: " + (Sprite2Almas != null));
                break;

            case 3:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite3Almas;
                Debug.Log("Asignando Sprite3Almas: " + (Sprite3Almas != null));
                break;

        }
    }
}
