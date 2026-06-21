using UnityEngine;

public class SwitchEjemplos : MonoBehaviour
{
    public string PokemonAction;
    public enum PokemonType
    {
        None, //0
        Agua, //1
        Planta, //2
        Fuego, //3
        Electrico, //4
        Dragon //5
    }

    public enum TipoEnemigo
    {
        None, 
        DuendeMordedor,
        DuendeMinero,
        AlmaErrante,
    }
    public enum Boss
    {
        None, 
        Muki, 
        Serpiente, 
        Cerdo, 
        Sapo, 
        PumaZorro,
        Jarjacha,
        Toro,
        MoscaVerde,
        CriaturaMascaras,
    }

    public enum CombatAction
    {
        None,
        Attack,
        Backpack,
        Flee,
        Change
    }
    
    public PokemonType type;
    public TipoEnemigo tipoenemigo;
    public Boss boss;
    public CombatAction Action;


    void Start()
    {
        switch (Action)
        {
            case CombatAction.None:
                {
                    Debug.Log("No has seleccionado ninguna acción");
                }
                break;
            case CombatAction.Attack:
                {
                    Debug.Log("Atacando");
                }
                break;
            case CombatAction.Backpack:
                {
                    Debug.Log("Mochila");
                }
                break;
            case CombatAction.Flee:
                {
                    Debug.Log("Huir");
                }
                break;
            case CombatAction.Change:
                {
                    Debug.Log("Cambio");
                }
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}
