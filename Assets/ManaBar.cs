using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    public float currentMana;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MegaMan");
        currentMana = player.GetComponent<x>().mana;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("MegaMan");
        currentMana = player.GetComponent<x>().mana;
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = currentMana / 180;
    }
}
