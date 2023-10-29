using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public string IceWin;
    public string FireWin;


    public void IceWon()
    {
        SceneManager.LoadScene(IceWin);
    }
    public void FireWon()
    {
        SceneManager.LoadScene(FireWin);
    }
}
