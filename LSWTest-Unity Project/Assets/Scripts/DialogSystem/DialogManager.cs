using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI playerDialogText;
    public TextMeshProUGUI entityDialogText;
   
    public DialogData initialDialog;
    public DialogData dialog;

    public Animator dialogAnim;
    public UnityEvent OnExitDialog;

    private void Start()
    {
        dialog = initialDialog;
    }

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
        Debug.Log("EXIT DIALOG");
    }
    
}
