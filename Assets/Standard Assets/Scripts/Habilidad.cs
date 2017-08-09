using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour {
	private int[,] tablero;
	// Use this for initialization
	public void InicializarTablero () {
		this.tablero = new int[10, 10];	//Despues hay que crear la clase tablero.
		Debug.Log(tablero.Length);
	}

	public void MostrarContenidoTablero () {
		int filaLength = tablero.GetLength (0);
		//int columnaLength = tablero.GetLength (1);

		for (int i = 0; i < filaLength; i++) {
			print (this.tablero[i, 0] + "" + this.tablero[i, 1] + "" + this.tablero[i, 2] + "" + this.tablero[i, 3] + "" + 
				this.tablero[i, 4] + "" + this.tablero[i, 5] + "" + this.tablero[i, 6] + "" + this.tablero[i, 7] + "" +
				this.tablero[i, 8] + "" + this.tablero[i, 9]);
		}
	}

	public void AtacarUnaPosicion () {	//Cuando lo hagamos funcionar deberia recibir de parametro un objeto Casilla 
		Casilla casilla = Casilla.CreateInstance(3, 4, 1); //Hardcodeado para prueba
		this.tablero [casilla.GetFila (), casilla.GetColumna ()] = 1;
	}

	public void AtacarDosPosiciones () { //Cuando lo hagamos funcionar deberia recibir de parametro dos objetos Casilla
		Casilla casilla1 = Casilla.CreateInstance(7, 8, 1); //Hardcodeado para prueba
		Casilla casilla2 = Casilla.CreateInstance(7, 9, 1); //Hardcodeado para prueba
		this.tablero [casilla1.GetFila (), casilla1.GetColumna ()] = 1;
		this.tablero [casilla2.GetFila (), casilla2.GetColumna ()] = 1;
	}

	public void AtacarConArtilleriaRapida () { //Podriamos recibir las dos casillas de las puntas y usar columnas y filas para calcular el area
		Casilla casilla1 = Casilla.CreateInstance(1, 1, 1);//Hardcodeado para prueba
		Casilla casilla2 = Casilla.CreateInstance(6, 6, 1); //Hardcodeado para prueba
		int[] area = new int[25];
		int random; 
		for (int i = 0; i < 5; i++) {
			random = Random.Range (0, 24);
			while (area [random] == 1) {
				random = Random.Range (0, 24);
			}
			area [random] = 1;
		}
		int k = 0;
		for (int i = casilla1.GetFila (); i < casilla2.GetFila (); i++) {
			for (int j = casilla1.GetColumna (); j < casilla2.GetColumna (); j++) {
				if (area [k] == 1) {
					this.tablero [casilla1.GetFila () + i, casilla1.GetColumna () + j] = 1;
				}
				k++;
			}
		}
	}

	public void AtacarConProyectilAltamenteExplosivo() { //Recibe solo una posicion e impacta en las 4 cercanas, si es posible
		Casilla casilla = Casilla.CreateInstance(5, 6, 1); //Hardcodeado para prueba, Ataque completo
		//Casilla casilla = Casilla.CreateInstance(0, 3, 1); //Hardcodeado para prueba, Ataque sin extremo superior
		//Casilla casilla = Casilla.CreateInstance(9, 6, 1); //Hardcodeado para prueba, Ataque sin extremo inferior
		//Casilla casilla = Casilla.CreateInstance(4, 0, 1); //Hardcodeado para prueba, Ataque sin extremo izquierdo
		//Casilla casilla = Casilla.CreateInstance(5, 9, 1); //Hardcodeado para prueba, Ataque sin extremo derecho
		this.tablero [casilla.GetFila (), casilla.GetColumna ()] = 1;
		if (casilla.GetFila () != 0) {
			this.tablero [casilla.GetFila () - 1, casilla.GetColumna ()] = 1;		
		}
		if (casilla.GetFila () != 9) {
			this.tablero [casilla.GetFila () + 1, casilla.GetColumna ()] = 1;	
		}
		if (casilla.GetColumna () != 0) {
			this.tablero [casilla.GetFila (), casilla.GetColumna () - 1] = 1;		
		}
		if (casilla.GetColumna () != 9) {
			this.tablero [casilla.GetFila (), casilla.GetColumna () + 1] = 1;	
		}
	}

	public void AtacarConTorpedo () {
	}

	public void Reparar () {
	}

	public void UtilizarReconocimientoSatelital () {
	}

	public void UtilizarPulsoElectromagnetico () {
	}

	public void UtilizarManiobrasEvasivas () {
	}

	public void CrearBarcoFantasma () {
	}

	public void ReforzarArmadura () {
	}

}
