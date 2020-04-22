using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextbox : MonoBehaviour
{
 [SerializeField]
 Text dialog;

 public string TextDialog
 {
     set => dialog.text = value;
 }

 public void Animate()
 {
     
 }


}
