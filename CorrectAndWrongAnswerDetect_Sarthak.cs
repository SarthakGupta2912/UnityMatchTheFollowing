using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAndWrongAnswerDetect_Sarthak : MonoBehaviour
{
    [SerializeField] MainManager mainManager;
    [SerializeField] QuizManager2_alimentaryCanal _quizManager2AlimentaryCanal;
    public void CorrectOrWrongAnswerDetect(AudioClip audioClip)
    {
        if (this.tag == "Correct")
        {
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().color = Color.green;
            _quizManager2AlimentaryCanal.correctAnswerCounter++;
            mainManager.audioSource.Pause();
            mainManager.audioSource.clip = audioClip;

            Debug.Log("Correct Answer!");
        }
        else
        {
            mainManager.PlayAudio(audioClip);
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<Image>().color = Color.red;
            mainManager.PlayAudio(audioClip);

            Debug.Log("Wrong Answer!");
        }
    }
}
