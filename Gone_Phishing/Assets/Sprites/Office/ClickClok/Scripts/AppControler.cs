using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class AppControler : MonoBehaviour
{
    // Start is called before the first frame update

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;
    public Image image7;
    public Image image8;
    public Image image9;
    public Image image10;
    public Image image11;
    public Image image12;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI dialogueText;
    public TextAsset dialogueFile;
    string[] dialogueList;
    int dialogueIndex = 0;

    int checkInt = 9;
    float swapTime = 1.75f;

    int score =0;
    int attempts =0;

    public GameObject dialogueBox;
    public Button tutorialButton;
    public Image tutorialImage;

    public Image endScreen;
    public Button endButton;
    public float endScreenTime = 5.0f;
    


    string[] imageList = {"image1", "image2", "image3", "image4", "image5", "image6", "image7", "image8", "image9", "KK", "image11", "image10"};
    void Start()
    {
        dialogueList = dialogueFile.text.Split(';');
        dialogueBox.gameObject.SetActive(false);
        scoreText.text = "Score: " + score;
        ResetApps();
        tutorialButton.onClick.AddListener(EndTutorial);
        button1.onClick.AddListener(delegate {WhichButton(0);});
        button2.onClick.AddListener(delegate {WhichButton(1);});
        button3.onClick.AddListener(delegate {WhichButton(2);});
        button4.onClick.AddListener(delegate {WhichButton(3);});
        button5.onClick.AddListener(delegate {WhichButton(4);});
        button6.onClick.AddListener(delegate {WhichButton(5);});
        button7.onClick.AddListener(delegate {WhichButton(6);});
        button8.onClick.AddListener(delegate {WhichButton(7);});
        button9.onClick.AddListener(delegate {WhichButton(8);});
        button10.onClick.AddListener(delegate {WhichButton(9);});
        button11.onClick.AddListener(delegate {WhichButton(10);});
        button12.onClick.AddListener(delegate {WhichButton(11);});
        endButton.onClick.AddListener(EndGame);
    }

    void EndTutorial(){
        tutorialImage.gameObject.SetActive(false);
    }

    void EndGame(){
        SceneManager.LoadScene(7);
    }

    // Update is called once per frame
    void Update()
    {
        swapTime -= Time.deltaTime;
        if(swapTime <= 0){
            ResetApps();
            swapTime = 1.75f;
        }

        if(attempts >= 8){
            swapTime = 10000f;
            int tonyIndex =0;
            foreach(string check in imageList){
                if(check == "KK"){
                    break;
                }
                tonyIndex++;
            }
            switch(tonyIndex){
                case 0:
                    Object.Destroy(image1);
                    button1.gameObject.SetActive(false);
                    break;
                case 1:
                    Object.Destroy(image2);
                    button2.gameObject.SetActive(false);
                    break;
                case 2:
                    Object.Destroy(image3);
                    button3.gameObject.SetActive(false);
                    break;
                case 3:
                    Object.Destroy(image4);
                    button4.gameObject.SetActive(false);
                    break;
                case 4:
                    Object.Destroy(image5);
                    button5.gameObject.SetActive(false);
                    break;
                case 5:
                    Object.Destroy(image6);
                    button6.gameObject.SetActive(false);
                    break;
                case 6:
                    Object.Destroy(image7);
                    button7.gameObject.SetActive(false);
                    break;
                case 7:
                    Object.Destroy(image8);
                    button8.gameObject.SetActive(false);
                    break;
                case 8:
                    Object.Destroy(image9);
                    button9.gameObject.SetActive(false);
                    break;
                case 9:
                    Object.Destroy(image10);
                    button10.gameObject.SetActive(false);
                    break;
                case 10:
                    Object.Destroy(image11);
                    button11.gameObject.SetActive(false);
                    break;
                case 11:
                    Object.Destroy(image12);
                    button12.gameObject.SetActive(false);
                    break;
            }
            endScreen.gameObject.SetActive(true);
        }
        
    }

    void Shuffle(string[] imageList){
        for(int j =0; j<2; j++){
        for(int i = 0; i < imageList.Length; i++){
            int randomIndex = Random.Range(0, imageList.Length);
            int randomIndex2 = Random.Range(0, imageList.Length);
            string temp = imageList[randomIndex2];
            imageList[randomIndex2] = imageList[randomIndex];
            imageList[randomIndex] = temp;
        }
        }
    }


    void CheckCorrect(){
        dialogueBox.gameObject.SetActive(true);
        dialogueText.text = dialogueList[dialogueIndex];
        dialogueIndex++;
        if(imageList[checkInt] == "KK"){
            score++;
            scoreText.text = "Score: " + score;
            attempts++;
        }
        else{
            score--;
            scoreText.text = "Score: " + score;
            attempts++;
        }
        ResetApps();
    }
    void ResetApps(){
        Shuffle(imageList);
        image1.sprite = Resources.Load<Sprite>("Apps/" + imageList[0]);
        image2.sprite = Resources.Load<Sprite>("Apps/" + imageList[1]);
        image3.sprite = Resources.Load<Sprite>("Apps/" + imageList[2]);
        image4.sprite = Resources.Load<Sprite>("Apps/" + imageList[3]);
        image5.sprite = Resources.Load<Sprite>("Apps/" + imageList[4]);
        image6.sprite = Resources.Load<Sprite>("Apps/" + imageList[5]);
        image7.sprite = Resources.Load<Sprite>("Apps/" + imageList[6]);
        image8.sprite = Resources.Load<Sprite>("Apps/" + imageList[7]);
        image9.sprite = Resources.Load<Sprite>("Apps/" + imageList[8]);
        image10.sprite = Resources.Load<Sprite>("Apps/" + imageList[9]);
        image11.sprite = Resources.Load<Sprite>("Apps/" + imageList[10]);
        image12.sprite = Resources.Load<Sprite>("Apps/" + imageList[11]);
        swapTime = 1.75f;
    }

    void WhichButton(int i){
        checkInt = i;
        CheckCorrect();
    }
}
