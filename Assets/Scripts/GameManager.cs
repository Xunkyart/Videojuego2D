using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int vidas = 7;

    static public int dinero = 0;

    GameObject Player;

    GameObject dineroObj;
    public GameObject panelDerrota;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");

        dineroObj = GameObject.Find("DineroObj");
        panelDerrota.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // VIDA Y RESPAWN
        if (vidas <= 0){
           panelDerrota.SetActive(true);
        }

        if (vidas > 6)
        {
            vidas = 6;
        } 

        // DINERO ui
        dineroObj.GetComponent<TextMeshProUGUI>().text = dinero.ToString();
    }

   
    public void VovlerInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}


