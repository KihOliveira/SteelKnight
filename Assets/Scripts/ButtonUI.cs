using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string level;
    
    public void restartGame(){
        SceneManager.LoadScene(level);

    }


}
