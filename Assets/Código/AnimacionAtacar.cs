using UnityEngine;

public class AnimacionAtacar : MonoBehaviour
{
    public Animator Animacion;

    void Start()
    {
        
    }

    void Update()
    {
        AnimarAtaque();
    }
    private void AnimarAtaque()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Animacion.SetTrigger("Atacando");
        }
    }
}
