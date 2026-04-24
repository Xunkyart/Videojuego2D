using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioClip bandaSonora;
   public AudioClip clipBotones;
   public AudioClip clipMonedas;
   public AudioClip clipMuerte;
   public AudioClip clipFuego;
   public static AudioManager Instance;

    void Awake()
    {
        if( Instance !=null && Instance != this.gameObject)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().clip = bandaSonora;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonarClipUnaVez(AudioClip sonidoClip)
    {
        GetComponent<AudioSource>().PlayOneShot(sonidoClip);
    }
}
