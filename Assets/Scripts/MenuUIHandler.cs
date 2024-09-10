using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    private ColorHandler colorHandlerScript;
    private Color lastSelectedColor;
    private string sceneName;


    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        colorHandlerScript = GetComponent<ColorHandler>();
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public Color SaveSelectedColor()
    {
        Debug.Log(ColorPicker.GetSelectedColor());
        return ColorPicker.GetSelectedColor();
    }

    public void SaveLastSelectedColor()
    {
        lastSelectedColor = ColorPicker.GetSelectedColor();
    }

    public void LoadSelectedColor()
    {
        colorHandlerScript.SetColor(ColorPicker.GetSelectedColor());
    }

    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        colorHandlerScript.SetColor(SaveSelectedColor());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
