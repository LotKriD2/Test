using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Класс для перемешения предмета

public class TouchController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _transform;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    void OnMouseDown()
    {
        _rb.isKinematic = true; //Отключение физики при перемешении предмета
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Получение вектора координат курсора
        _transform.position = new Vector2(mousePosition.x, mousePosition.y); //Перемешение предмета к курсуру
    }

    void OnMouseUp()
    {
        if(!GetComponent<TargetInfo>().IsOverTarget) //Проверка того, что предмет не находится на твёрдой поверхности
        {
            _rb.isKinematic = false; //Включаем физику предмета, если он не на твёрдой поверхности
        }

        _rb.velocity = Vector2.zero; //Обнуление скорости предмета
    }
}
