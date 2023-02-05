using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SecondGma : MonoBehaviour
{
    // Start is called before the first frame update
float displayTime = 4.0f;
    public GameObject dialogueBox;
    public ParticleSystem printerFixed;
    float timerDisplay;
    public TextAsset dialogueFile;
    string[] dialogueOrder;
    public int dialogueMaxIndex = 0;
    int dialogueIndex =0;

    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        timerDisplay = -1.0f;
        dialogueOrder = dialogueFile.text.Split(';');
    }
        

    // Update is called once per frame
    void Update()
    {
     if(timerDisplay >= 0){
        timerDisplay -= Time.deltaTime;

        if(timerDisplay < 0){
            dialogueBox.SetActive(false);
        }
     }   
     
    }

    public void DisplayDialogue(){
        dialogueBox.SetActive(true);
        if(printerFixed.isStopped){
        if(dialogueIndex < dialogueOrder.Length){
            dialogueText.text = dialogueOrder[dialogueIndex];
        }
        timerDisplay = displayTime;
        dialogueIndex++;
        }else{
            dialogueText.text = "I see you have the manual. You should be able to fix the printer now.";
            timerDisplay = displayTime;
        }
        
        
    }
}
