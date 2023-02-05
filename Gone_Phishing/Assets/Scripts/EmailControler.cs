using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class EmailControler : MonoBehaviour
{
    TextMeshProUGUI emailText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI emailTitle;
    public TextMeshProUGUI emailSender;
    public TextMeshProUGUI sendText;
    public TextMeshProUGUI cancelText;
    public Button sendButton;
    public Button cancelButton;
    string[] tempemailList;

    ArrayList emailList = new ArrayList();
    public TextAsset emailFile;

    string[] emailInfo;

    float score =0;
    int emailsSent = 0;
    public TextAsset phishDialogue;
    string[] phishDialogueOrder;
    public TextMeshProUGUI phishDialogueText;
    public Image dialogBox;
    public Button tutorialButton;

    public Image tutorialScreen;
    public Image endScreen;
    public Button endButton;




    // Start is called before the first frame update
    void Start()
    {
        emailText = this.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        tempemailList = emailFile.text.Split(';');
        emailList.AddRange(tempemailList);
        updateEmail();
        sendButton.onClick.AddListener(SendEmail);
        cancelButton.onClick.AddListener(CancelEmail);
        emailText.color = new Color(0,0,0,1);
        scoreText.text = "Score: " + score.ToString();
        phishDialogueOrder = phishDialogue.text.Split(';');
        phishDialogueText.text = "";
        dialogBox.gameObject.SetActive(false);
        tutorialButton.onClick.AddListener(startGame);
        endButton.onClick.AddListener(endGame);
        

    }

    void endGame(){
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        if(emailsSent >= 10){
            endScreen.gameObject.SetActive(true);
            sendButton.gameObject.SetActive(false);
            cancelButton.gameObject.SetActive(false);
        }
       
    }

    void SendEmail(){
        dialogBox.gameObject.SetActive(true);
        phishDialogueText.text = phishDialogueOrder[emailsSent];
    if(emailsSent < 10){
            if(emailInfo[5] == "ACCEPT"){
                score += 1;
            }
            else{
                score -= 1;
            }
        scoreText.text = "Score: " + score.ToString();
        emailsSent++;
        if(emailsSent < 9){
            updateEmail();
        }
    }
       
        
    }

    void CancelEmail(){
        dialogBox.gameObject.SetActive(true);
        phishDialogueText.text = phishDialogueOrder[emailsSent];
        if(emailsSent < 10){
           if(emailInfo[5] == "ACCEPT"){
            score -= 1;
        }
        else{
            score += 1;
        }
        scoreText.text = "Score: " + score.ToString();
        emailsSent++;
        if(emailsSent < 9){
            updateEmail();
        }
        
    }
        
    }

    void updateEmail(){
        int random = Random.Range(0, emailList.Count);
        emailInfo = emailList[random].ToString().Split('*');
        emailList.Remove(emailList[random].ToString());
        emailText.text = emailInfo[2];
        emailSender.text = emailInfo[0];
        emailTitle.text = emailInfo[1];
        cancelText.text = emailInfo[3];
        sendText.text = emailInfo[4];
    }

    void startGame(){
        tutorialScreen.gameObject.SetActive(false);
        Debug.Log("Start Game");
    }
}
