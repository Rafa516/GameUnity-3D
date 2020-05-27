using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour {

	public void Jogar()
    {
        SceneManager.LoadScene("Cenario");
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
