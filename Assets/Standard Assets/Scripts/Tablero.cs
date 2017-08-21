using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : ScriptableObject {

	private int idJugador;
	private Casilla[,] casillas;

	// Use this for initialization
	public void Init (int idJugador, Barco [] barcos) {
		this.idJugador = idJugador;
		this.InicializarTablero ();
		if (barcos != null) {
			this.InicializarTableroPosiciones (barcos);
		}
	}

	public static Tablero CreateInstance(int idJugador, Barco[] barcos = null)
	{
		var data = ScriptableObject.CreateInstance<Tablero>();
		data.Init(idJugador, barcos);
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

	public void InicializarTableroPosiciones (Barco [] barcos) {
		for(int i=0; i<barcos.Length; i++) {
			Casilla [] posicionesOcupadas = barcos [i].GetPosicionesOcupadas ();
			for (int j=0; j<posicionesOcupadas.Length; j++) {
				this.casillas [posicionesOcupadas[j].GetFila (), posicionesOcupadas[j].GetColumna ()].SetHayBarco (true);
			}
		}
	}

	public int GetLongitud () {
		return this.casillas.Length;
	}

	public Casilla GetCasilla (int fila, int columna) {
		return this.casillas [fila, columna];
	}

	public int GetEstadoCasilla (int fila, int columna) {
		return this.casillas [fila, columna].GetEstado ();
	}

	public bool GetHayBarco (int fila, int columna) {
		return this.casillas [fila, columna].GetHayBarco ();
	}

	public bool GetHayCasillaReforzada (int fila, int columna) {
		return this.casillas [fila, columna].GetHayCasillaReforzada ();
	}

	public bool GetHayBarcoFantasma (int fila, int columna) {
		return this.casillas [fila, columna].GetHayBarcoFantasma ();
	}

	public void SetEstadoCasilla (int fila, int columna, int estado) {
		this.casillas [fila, columna].SetEstado (estado);
	}

	public void SetHayBarco (int fila, int columna, bool hayBarco) {
		this.casillas [fila, columna].SetHayBarco (hayBarco);
	}

	public void SetHayCasillaReforzada (int fila, int columna, bool hayCasillaReforzada) {
		this.casillas [fila, columna].SetHayCasillaReforzada (hayCasillaReforzada);
	}

	public void SetHayBarcoFantasma (int fila, int columna, bool hayBarcoFantasma) {
		this.casillas [fila, columna].SetHayBarcoFantasma (hayBarcoFantasma);
	}
}
