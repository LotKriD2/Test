using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс для определения столкновения предмета с поверхностью

public class TargetInfo : MonoBehaviour
{

    private float _delta, _minBoundsY, _maxBoundsY; //Переменная для разделения зон, нижняя и вышняя границы фона по y.

    private bool _isOverTarget = false; // Переменная, хранящая информацию о том, что предмет находится на твёрдой поверхности

    //// Открывает доступ к данным переменным из других классов
    public bool IsOverTarget => _isOverTarget;
    public float Delta => _delta;
    public float MinBoundsY => _minBoundsY;
    public float MaxBoundsY => _maxBoundsY;

    void Start()
    {
        //Получает SpriteRender фона для определения размеров зон
        SpriteRenderer spriteRender = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
        _maxBoundsY = spriteRender.bounds.max.y;
        _minBoundsY = spriteRender.bounds.min.y;
        _delta = (_maxBoundsY - _minBoundsY) / 4;
    }
    
    //Определение находится ли предмет на твёрдой поверхности
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Target"))
        {
            _isOverTarget = true;
        }
    }

    //Определение находится ли предмет не на поверхности
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Target"))
        {
            _isOverTarget = false;
        }
    }
}
