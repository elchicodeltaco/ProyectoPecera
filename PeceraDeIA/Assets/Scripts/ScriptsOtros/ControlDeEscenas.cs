using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlDeEscenas : MonoBehaviour
{
  public void CargarScena(string nombre)
    {
      SceneManager.LoadScene(nombre);
    }

    public void CargarScena(int indice)
    {
        
        SceneManager.LoadScene(indice);
    }
}
