using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ScriptableObject template for dialog info
[CreateAssetMenu(fileName = "New dialog", menuName = "Dialog")]
public class DialogData : ScriptableObject
{
    public string entityDialog;//the dialogue of the entity that will speak with the player
    public string playerDialog;//the response that the player can make regarding the entity's dialogue (unfortunately I did not have time to make it have a configurable number of responses)
    public DialogData nextDialog;//once the player responds, that response leads to another dialogue.
}
