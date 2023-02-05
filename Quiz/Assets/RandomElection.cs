using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomElection : MonoBehaviour
{


    public int numberQuestion;
    public int contador = 0;
    public int countQuestions = 0;
    public List<int> numberRandom;
    public bool stop = false;
    public GameObject[] preguntas;
    public int puntos = 0;
    public GameObject panelFinal;
    public TextMeshProUGUI textoPuntos;


    // Start is called before the first frame update
    void Start()
    {

        while (!stop)
        {
            int temp = Random.Range(0, numberQuestion - 1);
            if (!numberRandom.Contains(temp))
            {
                numberRandom.Add(temp);
                contador++;
            }
            if (contador == numberQuestion - 1)
            {
                break;
            }
        }
        preguntas[numberRandom[countQuestions]].SetActive(true);
    }

     void Update()
    {
        if(preguntas.Length - 1 == countQuestions)
        {
            panelFinal.SetActive(true);
            textoPuntos.text = puntos.ToString();
        }
        
    }


    public void ActiveQuestion()
    {

        preguntas[numberRandom[countQuestions]].SetActive(false);
        countQuestions++;
        preguntas[numberRandom[countQuestions]].SetActive(true);

    }

    public void OpcionCorrecta(Button _Button)
    {
        StartCoroutine(OpcionCorrectaCoroutine(_Button));
    }

    public void OpcionIncorrecta(Button _Button)
    {
        StartCoroutine(OpcionIncorrectaCoRoutine(_Button));
    }


    public IEnumerator OpcionCorrectaCoroutine(Button _Button)
    {
        _Button.image.color = Color.green;
        yield return new WaitForSeconds(1);
        puntos += 100;
        //puntos++;
        ActiveQuestion();

    }

    public IEnumerator OpcionIncorrectaCoRoutine(Button _Button)
    {
        _Button.image.color = Color.red;
        yield return new WaitForSeconds(1);
        ActiveQuestion();
    }


    

}