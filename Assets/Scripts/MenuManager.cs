using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        NameInput.text = DataManager.Instance.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.SetName(NameInput.text);
        SceneManager.LoadScene(1);
    }
}
