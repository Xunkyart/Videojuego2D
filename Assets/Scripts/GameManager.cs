using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public int vidas = 7;

    static public int dinero = 0;

    GameObject Player;

    GameObject dineroObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");

        dineroObj = GameObject.Find("DineroObj");
    }

    // Update is called once per frame
    void Update()
    {
        // VIDA Y RESPAWN
        if (vidas <= 0){
           Player.GetComponent<Movimiento>().Respawnear();
            vidas = 7;
        }

        if (vidas > 6)
        {
            vidas = 6;
        } 

        // DINERO ui
        dineroObj.GetComponent<TextMeshProUGUI>().text = dinero.ToString();
    }

}
