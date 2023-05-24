
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AnswerAndQuestionSO[] data;
   
    [SerializeField]   
    private int index;   



    [SerializeField]
    private Text question;   


    [SerializeField]
    private GameObject[] btns;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;

    private string auxString;

    private List<int> auxList;
    private List<int> auxListIndex;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        auxList = new List<int>();
        auxListIndex = new List<int>();
        RandomQuestion();
        question.text = data[index].question;
        DelegateBtnsAnswers();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnAction(string answer)
    {

       if(answer.Equals(data[index].answer, StringComparison.OrdinalIgnoreCase)) {
            
            CorrectAnswer();
            ScoreProvider.instance.AddScore();
       }
        else
        {
            WrongAnswer();

        }
    }

    public void DelegateBtnsAnswers()
    {
        for(int i = 0; i < btns.Length; i++)
        {
            RandomAnswer();
            string answer = auxString; 
            btns[i].GetComponent<Button>().onClick.AddListener(() => BtnAction(answer));
            Text text = btns[i].GetComponentInChildren<Text>();
            text.text = answer;
            
        }
    }

    public void RandomAnswer()
    {
        int x;

        do
        {
            x = UnityEngine.Random.Range(1, 5);
        }
        while (auxList.Contains(x));

        auxList.Add(x);
        Choose(x);
    }


    public void Choose(int x)
    {
        switch (x)
        {
            case 1:
            auxString = data[index].wrongA; 
            break;

            case 2:
            auxString = data[index].wrongB;
            break;

            case 3:
            auxString = data[index].wrongC;
            break;

            case 4:
            auxString = data[index].answer;
            break;
        }
    }

    public void CorrectAnswer()
    {
        Timer.instance.AddTimer();
        for (int i = 0; i < btns.Length; i++)
        {
            
            btns[i].GetComponent<Button>().onClick.RemoveAllListeners();
            

        }
        auxList.Clear();
        RandomQuestion();
        question.text = data[index].question;
        DelegateBtnsAnswers();
    }

    public void WrongAnswer()
    {
        ScoreProvider.instance.SaveScore();
        losePanel.SetActive(true);
    }

   
    public void RandomQuestion()
    {
        int x;
        if(auxListIndex.Count == 10)
        {
            ScoreProvider.instance.SaveScore();
            winPanel.SetActive(true);
        }
        else
        {
            do
            {
                x = UnityEngine.Random.Range(0, data.Length);
            }
            while (auxListIndex.Contains(x));
            auxListIndex.Add(x);
            index = x;
        }
        
    }
}
