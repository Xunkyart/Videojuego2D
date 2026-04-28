using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptUIVictoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public GameObject panelUI;
    GameObject player;
    GameObject manoSprite;
    GameObject fantasmas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //eL PANEL DE VICTORIA EMPIEZA APAGADO
    void Start()
    {
        panelVictoria.SetActive(false);
        
        player = GameObject.FindWithTag("Player");
        manoSprite = GameObject.Find("ManoSprite");
        fantasmas = GameObject.Find("==PELIGRO==");
    }

    //SI ENTRAS EN EL COLLIDER TRIGGER, SE ACTIVA UNA ANIMACIÓN Y UN TEMPORIZADOR

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger");
        if(col.name == "Player")
        {
            manoSprite.GetComponent<Animator>().SetBool("Cerrar",true);
            StartCoroutine(IniciarTemporizador());
        }
    }

    //TRAS ACBAR LA ANIAMCIÓN, EL PERSONAJE SE DESTRUYE Y APARECE EL PANEL DE VICTORIA
    //Destruyo los fantasmas también porque al necesiatr en todo momento la posición del personaje, sacan un error si destruyo al personaje
    IEnumerator IniciarTemporizador(){
        yield return new WaitForSeconds(1.1f);
        player.SetActive(false);
        fantasmas.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        panelUI.SetActive(false);
        panelVictoria.SetActive(true);
    }

     public void VovlerInicio()
    {
        player.SetActive(true);
        fantasmas.SetActive(true);
        SceneManager.LoadScene("Inicio");
    }
}
