using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] GameObject restartBttnPanel;
    // Update is called once per frame
    void Update()
    {
       
    }

   public void OnClickBttn()
    {
        restartBttnPanel.SetActive(false);
        SceneManager.LoadSceneAsync(0);   
    }
}
