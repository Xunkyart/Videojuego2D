using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Animator coinAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(col.name == "Player")
        {
            GameManager.dinero += 1;
            Destroy(this.gameObject, 0f);
        }
    }
}
