using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DogeInteraction : MonoBehaviour
{
    // Start is called before the first frame update
   float displayTime = 4.0f;
    public GameObject dialogueBox;
    float timerDisplay;
    public TextAsset dialogueFile;
    string[] dialogueOrder;
    public int dialogueMaxIndex = 0;
    int dialogueIndex =0;
    public int sceneIndex = 2;

    public TextMeshProUGUI dialogueText;

    SpriteRenderer Doge;
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        timerDisplay = -1.0f;
        dialogueOrder = dialogueFile.text.Split(';');
        Doge = GetComponent<SpriteRenderer>();
    }
        

    // Update is called once per frame
    void Update()
    {
     if(timerDisplay >= 0){
        timerDisplay -= Time.deltaTime;

        if(timerDisplay < 0){
            dialogueBox.SetActive(false);
            if(dialogueIndex == dialogueMaxIndex){
                Doge.sprite = newSprite;
            }
        }
     }   
     
    }

    public void DisplayDialogue(){
        dialogueBox.SetActive(true);
        if(dialogueIndex < dialogueOrder.Length){
            dialogueText.text = dialogueOrder[dialogueIndex];
        }
        timerDisplay = displayTime;
        dialogueIndex++;
        
    }

}
