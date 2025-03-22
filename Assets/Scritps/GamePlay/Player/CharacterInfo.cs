﻿using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;


public class CharacterInfo : MonoBehaviour, IDameable
{
    [SerializeField] private PlayerData player;


    public int Dame { get => currentDame; }
    public float Speed { get => currentSpeed; }
    public float Mana { get => currentMana; set => currentMana = value; }

    private int currentDame;
    private float currentMana, currentSpeed, currentHp;

    private float manaRate = 5, maxMana;
    private bool isRegenRating = false;
    // public float CurrentHP { get => currentHp; set => currentHp = value; }

    int index;
   
    private void Awake()
    {
        index = PlayerPrefs.GetInt(StringSave.selectionCharacter);
        index++;
        string playerStr = "Player" + index;
        if (player == null) player = Resources.Load<PlayerData>("SO/Player/" + playerStr + "");
    }
    private void OnEnable()
    {
        UpdateDataforCharacter();
    }
    void UpdateDataforCharacter()
    {
        currentDame = player.dame;
        currentHp = player.hp;
        currentMana = player.mp;
        currentSpeed = player.speed;


        maxMana = currentMana;
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentMana < maxMana && currentMana<20 )
        //{
        //    RegenMana();
        //}
    }

    public void TakeDame(int dame)
    {
        currentHp -= dame; // trừ máu hiện tại theo dame

        // Debug.Log("hien thi current dame"+ currentHp);
        if (currentHp <= 0)
        {
            GameManager.Instance.GameOver(); //máu bằng 0 sẽ game over
        }

    }

    public void ReductionMana(int mana)
    {
        if (currentMana >= mana)
        {
            currentMana -= mana;

            if (currentMana <= 0)
            {
                currentMana = 0;

            }
        }
    }

    public void RegenMana()
    {


        isRegenRating = true;

        StartCoroutine(RegenManaCoroutine());

    }

    IEnumerator RegenManaCoroutine()
    {
        // nếu đúng  điều kiện  và isRegenRating bằng true
        while (currentDame < maxMana && isRegenRating)
        {
            yield return new WaitForSeconds(0.5f);  
            currentMana += manaRate * Time.deltaTime;
            if (currentMana >= maxMana)
            {
                currentMana = maxMana; // nếu mana bằng hoặc hơn maxMana thì sẽ cho bằng maxMana

                isRegenRating= false;
            } 

            Debug.Log(currentMana);

            yield return null;
        }

        isRegenRating = false;
    }
}


