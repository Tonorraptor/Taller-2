using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScripMenu : MonoBehaviour
{
    [SerializeField] private GameObject PanelJugar;
    [SerializeField] private GameObject PanelOpciones;

    public void SubMenuJugar()
    {
        PanelJugar.SetActive(true);
        PanelOpciones.SetActive(false);
    }
    public void SubMenuOpciones()
    {
        PanelJugar.SetActive(false);
        PanelOpciones.SetActive(true);
    }
    public void Cerrar()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Game");
    }
    public void TutorialBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
