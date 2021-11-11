﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private int score;

    private int life;
    private ParticleSystem blockParticle;
    private SpriteRenderer spriteRenderer;
    private UIScore uiScore;
    private GameObject canvasScore;

    private void Awake()
    {
        life = spriteList.Count;
        blockParticle = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[spriteList.Count - 1];
    }

    private void Start()
    {
        canvasScore = GameObject.FindGameObjectWithTag("UiScore");
        uiScore = canvasScore.GetComponent<UIScore>();
    }

    public void ApplyDamage()
    {
        life -= 1;
        if (life < 1)
        {
            blockParticle.Play();
            spriteRenderer.enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            uiScore.ChangeScore(score);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[life - 1];
        }
    }
}
