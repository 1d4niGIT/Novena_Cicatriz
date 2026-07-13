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
        ActualizarIcono();
    }

    void Update()
    {
        
    }

    public void AgregarAlma()
    {
        if (AlmasSalvadas < MaximoAlmas)
        {
            AlmasSalvadas++;
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
        switch (AlmasSalvadas)
        {
            case 0:

                IconoAlmas.enabled = false;
                break;

            case 1:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite1Alma;
                break;

            case 2:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite2Almas;
                break;

            case 3:

                IconoAlmas.enabled = true;
                IconoAlmas.sprite = Sprite3Almas;
                break;

        }
    }
}
