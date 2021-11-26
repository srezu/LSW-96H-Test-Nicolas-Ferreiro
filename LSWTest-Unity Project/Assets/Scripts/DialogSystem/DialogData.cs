using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialog", menuName = "Dialog")]
public class DialogData : ScriptableObject
{
    public string entityDialog;
    public string playerDialog;
    public DialogData nextDialog;
}
