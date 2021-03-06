﻿using UnityEngine;
using System.Collections;
public class ForsvarselementAngrep : MonoBehaviour
{
	/* Dette skriptet håndterer funksjonen som kjøres når en fiende kommer innenfor
	 * forsvarselementets detectionarea
	 */
	public GameObject prosjektil; //Hva som skal skytes
	public Transform skyteposisjon; //Hvor det skal skytes fra
	public Transform skytter; //Sikterotasjonen
	private Transform target; //Hvem som skal skytes på
	private float tidForNesteSkudd; //Når neste skudd skal fyres av
	public float reloadTime =1f; //Hyppigheten av skudd
	public AudioClip shoot; //Lyd som kjøres når et prosjektil avfyres
	private AudioSource source; //Lydkilden

	void Start(){
		//legger komponentet til lydkilden
		source = GetComponent<AudioSource> ();
	}
	void FixedUpdate(){
		//Hvis forsvarseleme har fått et target  siktes det og skytes
		if (target) {
			if (Time.time >= tidForNesteSkudd) {
				//Ser på fienden
				skytter.transform.LookAt (target);
				Skyt ();
			}
		}
	}

	//Avfyrer skudd
	void Skyt(){
		//Kalkulerer tid for neste skudd
		tidForNesteSkudd = Time.time + reloadTime;
		//Instanserer prosjektilet fra skyteposisjonen
		Instantiate (prosjektil, skyteposisjon.position, skyteposisjon.rotation);
		source.PlayOneShot (shoot);
	}
	
	// Setter Target til Elementet som er sendt fra ConeCollideren "DetectArea"
	public void Target(Transform t){
		target = t;
		}	
}
