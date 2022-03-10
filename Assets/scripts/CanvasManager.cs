using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public GameObject canvasMenu;
    public GameObject canvasJeu;
    public GameObject canvasShop;

    public soundManagerController soundManagerController;

    private void Start() {
        soundManagerController = GameObject.Find("soundManager").GetComponent<soundManagerController>();
    }

    public void activerCanvasJeu() {
        soundManagerController.playSelect();
        canvasMenu.SetActive(false);
        canvasJeu.SetActive(true);
        canvasShop.SetActive(false);
    }

    public void activerCanvasMenu()
    {
        soundManagerController.playSelect();
        canvasMenu.SetActive(true);
        canvasJeu.SetActive(false);
        canvasShop.SetActive(false);
    }

    public void activerCanvasShop()
    {
        soundManagerController.playSelect();
        canvasMenu.SetActive(false);
        canvasJeu.SetActive(false);
        canvasShop.SetActive(true);
    }

}
