﻿using UnityEngine;
using System.Collections;

public class LitenVikingMovement : MonoBehaviour 
{
	/* Dette skripet setter funksjonen til den lille vikingen
	 */
	private NavMeshAgent nav;
	private Animator anim;
	private HashIDs hash;
	private Fiende fiende;
	private LitenVikingAngrep angrep;
	private bool angriper = false;
	private LitenVikingAnimatorSetup animSetup;
	private float originalSpeed;



	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		hash = GameObject.Find ("gameController").GetComponent<HashIDs> ();
		fiende =this.GetComponent<Fiende> ();
		angrep = GetComponent<LitenVikingAngrep> ();

		originalSpeed = nav.speed;
		//Kjører konstruktøren fra LitenViking AnimatorSetup
		animSetup = new LitenVikingAnimatorSetup (anim, hash);
	}

	void Update(){
		angriper = angrep.litenVikingAngriperBool;
		NavAnimSetup ();
	}


	//Kjører funksjonen som styrer animasjonen
	void NavAnimSetup(){
		float speed;
		float health;

		health = fiende.helse;
		speed = nav.speed;
		//Siden den lille vikingen slår med øks er den avhengig av å ikke bevegeseg. Farten blir derfor satt til null
		 if (angriper) {
			nav.speed = 0f;
		} else {
		
			nav.speed = originalSpeed;
		}
		animSetup.Setup (speed, health, angriper);

	}


}
