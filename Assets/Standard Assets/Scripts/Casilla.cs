using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : ScriptableObject {

	private int fila;
	private int columna;
	private int estado;

	// Use this for initialization
	public void Init (int fila, int columna, int estado) {
		this.fila = fila;
		this.columna = columna;
		this.estado = estado;
	}

	public static Casilla CreateInstance(int fila, int columna, int estado)
	{
		var data = ScriptableObject.CreateInstance<Casilla>();
		data.Init(fila, columna, estado);
		return data;
	}

	public int GetFila () {
		return this.fila;
	}

	public int GetColumna () {
		return this.columna;
	}

	public int GetEstado () {
		return this.estado;
	}

	public void SetFila (int fila) {
		this.fila = fila;	
	}

	public void SetColumna (int columna) {
		this.columna = columna;
	}

	public void SetEstado (int estado) {
		this.estado = estado;
	}
}
