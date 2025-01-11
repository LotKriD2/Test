using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс для изменения размера предмета, чтобы размещать его вглубине сцены

public class ScaleLvlObject : MonoBehaviour
{
    private Dictionary<string, float> _scaleLvl = 
    new Dictionary<string, float>
    {
        { "Selected", 0.07f },
        { "FirstPlace", 0.06f },
        { "SecondPlace", 0.05f },
        { "ThirdPlace", 0.04f },
        { "FourthPlace", 0.03f }
    }; //Словарь для хранения размеров предмета

    private Transform transform;
    private TargetInfo targetInfo;

    void Start()
    {
        transform = GetComponent<Transform>();
        targetInfo = GetComponent<TargetInfo>();
    }

    void OnMouseDown()
    {
        SetScaleLvl(_scaleLvl["Selected"]); //Увеличение размеров предмета при перемешении
    }

    /*
    Изменение размеров предмета в зависимости от глубины расположения на сцене.
    Для этого в классе TargetInfo фон делиться на 4 зоны, каждая из которых относится к своему размеру объекта.
    Для этого используется MinBoundsY - нижняя граница фона по координате y,
    Delta - переменная для разделения зон, равная разнице вышней границы по y и нижней по y, поделенная на 4.
    */
    void OnMouseUp()
    {       
        if(transform.position.y <= targetInfo.MinBoundsY + targetInfo.Delta)
        {
            SetScaleLvl(_scaleLvl["FirstPlace"]);
        }
        else if(transform.position.y > targetInfo.MinBoundsY + targetInfo.Delta &&
         transform.position.y <= targetInfo.MinBoundsY + targetInfo.Delta * 2)
        {
            SetScaleLvl(_scaleLvl["SecondPlace"]);
        }
        else if(transform.position.y > targetInfo.MinBoundsY + targetInfo.Delta * 2 &&
        transform.position.y <= targetInfo.MinBoundsY + targetInfo.Delta * 3)
        {
            SetScaleLvl(_scaleLvl["ThirdPlace"]);
        }
        else
        {
            SetScaleLvl(_scaleLvl["FourthPlace"]);
        }
    }

    //Функция для установки размеров объекта
    void SetScaleLvl(float scaleLvl)
    {
        transform.localScale = new Vector2(scaleLvl, scaleLvl);
    }
}
