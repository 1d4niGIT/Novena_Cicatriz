using UnityEngine;

public class ControlTutorial : MonoBehaviour
{
    public KeyCode TeclaParaCerrar = KeyCode.Space;
    public Animator WASDAnimacion;
    public Animator IndicadorAnimacion;
    private void Start()
    {
        WASDAnimacion.SetBool("Activado", true);
        IndicadorAnimacion.SetBool("Activado", true);
    }
    void Update()
    {
        if (Input.GetKeyDown(TeclaParaCerrar))
        {
            gameObject.SetActive(false);
        }
    }
}
