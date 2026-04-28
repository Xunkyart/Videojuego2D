using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptUIVictoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public GameObject panelDerrota;
    public GameObject panelUI;
    GameObject player;
    GameObject manoSprite;
    GameObject fantasmas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelVictoria.SetActive(false);
        panelDerrota.SetActive(false);
        player = GameObject.FindWithTag("Player");
        manoSprite = GameObject.Find("ManoSprite");
        fantasmas = GameObject.Find("==PELIGRO==");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger");
        if(col.name == "Player")
        {
            manoSprite.GetComponent<Animator>().SetBool("Cerrar",true);
            StartCoroutine(IniciarTemporizador());
        }
    }
    IEnumerator IniciarTemporizador(){
        yield return new WaitForSeconds(1.1f);
        Destroy(fantasmas);
        Destroy(player);
        yield return new WaitForSeconds(1.2f);
        panelUI.SetActive(false);
        panelVictoria.SetActive(true);
    }

     public void VovlerInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}
