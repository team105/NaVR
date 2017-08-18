using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : ScriptableObject {

	private int idJugador;
	private Casilla[,] casillas;

	// Use this for initialization
	public void Init (int idJugador) {
		this.idJugador = idJugador;
		this.InicializarTablero ();
	}

	public static Tablero CreateInstance(int idJugador)
	{
		var data = ScriptableObject.CreateInstance<Tablero>();
		data.Init(idJugador);
		return data;
	}

	public void InicializarTablero () {
		this.casillas = new Casilla[10, 10];
		for (int i=0; i<10; i++) {
			for (int j = 0; j < 10; j++) {
				this.casillas[i,j] = Casilla.CreateInstance(i, j, 0);
			}
		}
	}

	public int GetLongitud () {
		return this.casillas.Length;
	}

	public int GetEstadoCasilla (int fila, int columna) {
		return this.casillas [fila, columna].GetEstado ();
	}

	public void SetEstadoCasilla (int fila, int columna, int estado) {
		this.casillas [fila, columna].SetEstado (estado);
	}
}
