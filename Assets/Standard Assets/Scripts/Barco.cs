using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco : ScriptableObject {

	private Casilla[] posicionesOcupadas;
	private int tipoBarco;

	// Use this for initialization
	public void Init (Casilla [] posicionesOcupadas, int tipoBarco) {
		this.posicionesOcupadas = new Casilla[posicionesOcupadas.Length];
		for (int i=0; i< posicionesOcupadas.Length; i++) {
			this.posicionesOcupadas [i] = posicionesOcupadas [i];
		}
		this.tipoBarco = tipoBarco;
	}

	public static Barco CreateInstance(Casilla [] posicionesOcupadas, int tipoBarco)
	{
		var data = ScriptableObject.CreateInstance<Barco>();
		data.Init(posicionesOcupadas, tipoBarco);
		return data;
	}

	public Casilla[] GetPosicionesOcupadas () {
		return this.posicionesOcupadas;
	}
}
