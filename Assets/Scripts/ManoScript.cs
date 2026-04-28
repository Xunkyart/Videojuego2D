using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptUIVictoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public GameObject panelDerrota;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelVictoria.SetActive(false);
        panelDerrota.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
