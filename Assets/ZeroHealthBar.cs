using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroHealthBar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float currentHealth;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MegaMan");
        currentHealth = player.GetComponent<zero>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("MegaMan");
        currentHealth = player.GetComponent<zero>().hp;
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = currentHealth / 200;
    }
}
