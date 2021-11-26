using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


/*This class is in charge of handling the dialogs*/
public class DialogManager : MonoBehaviour
{
    [Header("Text references")]
    public TextMeshProUGUI playerDialogText;
    public TextMeshProUGUI entityDialogText;
   
    [Header("Dialog data")]
    public DialogData initialDialog;
    public DialogData dialog;

    [Header("Other")]
    public Animator dialogAnim;
    public UnityEvent OnExitDialog;

    private void Start()
    {
        dialog = initialDialog;
    }

    //This method is called when the player responds to a dialogue, to tell the system that it has to go to the next dialogue.
    public void NextDialog()
    {
        playerDialogText.text = dialog.playerDialog;
        entityDialogText.text = dialog.entityDialog;
        if (dialog.nextDialog)
        {
            dialog = dialog.nextDialog;
        }

        dialogAnim.Rebind();
        
        if (dialog.nextDialog == null || dialog.entityDialog == "")
        {
            ExitDialog();
        }
    }
    
    public void ExitDialog()
    {
        OnExitDialog.Invoke();
        dialog = initialDialog;
        NextDialog();
    }
    
}
