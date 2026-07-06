using UnityEngine;

public class AnimacionesDemonio : MonoBehaviour
{
    public Animator Animacion;
    void Start()
    {
        Animacion.SetFloat("X", 0);
        Animacion.SetFloat("Y", 0);
    }

    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector2 Dir = new Vector2(Horizontal, Vertical);

        Animacion.SetFloat("X", Dir.x);
        Animacion.SetFloat("Y", Dir.y);

        if (Input.GetMouseButtonDown(1))
        {
            Animacion.SetTrigger("EnAtaque");
        }
    }
}
