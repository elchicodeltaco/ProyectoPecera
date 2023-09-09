using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int vidas;

    public int puntos;

    public GameObject panelDeBotones;
    public Text vidasText;
    public Text PuntajeText;

    public Text GameOverText;

    private bool GameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        panelDeBotones.SetActive(false);
       // TextoFinPartida
        vidasText.text = "Vidas: " + vidas;

        GameOverText.gameObject.SetActive(false); 

        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitarVida()
    {
        vidas--;

        vidasText.text = "Vidas: " + vidas;

        if (vidas <= 0)
        {
            GameOver = true;
            Time.timeScale = 0f;
            panelDeBotones.SetActive(true);
        }

    }

    public void SumarPuntos()
    {
        puntos++;
        PuntajeText.text = puntos.ToString();   
    }


   
}
