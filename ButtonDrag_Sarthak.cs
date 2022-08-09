using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDrag_Sarthak : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 storeStartingPos;
    [SerializeField] GameObject comparePoint;
    //[SerializeField] QuizManager_alimentaryCanal quizManagerAlimentaryCanal;

    public void OnBeginDrag(PointerEventData eventData)
    {
        storeStartingPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Debug.Log("dragging");
        Debug.Log(this.GetComponent<RectTransform>().localPosition.x - comparePoint.GetComponent<RectTransform>().localPosition.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector2.Distance(this.transform.position, comparePoint.transform.position) <= 100f)
        {
            this.transform.position = new Vector2(comparePoint.transform.position.x, comparePoint.transform.position.y);

            comparePoint.GetComponent<Text>().text = this.gameObject.GetComponentInChildren<Text>().text;
            Destroy(this.gameObject);
            //quizManagerAlimentaryCanal.correctAnswerCounter++;
        }
        else
        {
            this.transform.position = storeStartingPos;
            storeStartingPos = new Vector3();
        }
    }
}
