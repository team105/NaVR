using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constantes {
	public const int NO_ATACADO_AGUA = 0;
	public const int YA_ATACADO_AGUA = 1;
	public const int NO_ATACADO_BARCO = 2;
	public const int YA_ATACADO_BARCO = 3;
}
	
public class Habilidad : MonoBehaviour {
	private int[,] tablero;
	// Use this for initialization
	public void InicializarTablero () {
		this.tablero = new int[10, 10];	//Despues hay que crear la clase tablero.
		Debug.Log(tablero.Length);
	}

	public void MostrarContenidoTablero () {
		int filaLength = tablero.GetLength (0);
		for (int i = 0; i < filaLength; i++) {
			print (this.tablero[i, 0] + "" + this.tablero[i, 1] + "" + this.tablero[i, 2] + "" + this.tablero[i, 3] + "" + 
				this.tablero[i, 4] + "" + this.tablero[i, 5] + "" + this.tablero[i, 6] + "" + this.tablero[i, 7] + "" +
				this.tablero[i, 8] + "" + this.tablero[i, 9]);
		}
	}

	public int AtacarUnaPosicion (Casilla casilla = null) {	//Cuando lo hagamos funcionar deberia recibir de parametro un objeto Casilla 
		//casilla = Casilla.CreateInstance(3, 4, 1); //Hardcodeado para prueba, descomentar para probar este ataque
		if (this.tablero [casilla.GetFila (), casilla.GetColumna ()] == Constantes.NO_ATACADO_BARCO) {
			this.tablero [casilla.GetFila (), casilla.GetColumna ()] = Constantes.YA_ATACADO_BARCO; //Ataque exitoso a un barco
			return 1;
		}
		else if (this.tablero [casilla.GetFila (), casilla.GetColumna ()] == Constantes.NO_ATACADO_AGUA) {
			this.tablero [casilla.GetFila (), casilla.GetColumna ()] = Constantes.YA_ATACADO_AGUA; //Ataque fallido que impacto en agua
			return 0;
		}
		return -1;
	}

	public void AtacarDosPosiciones () { //Cuando lo hagamos funcionar deberia recibir de parametro dos objetos Casilla
		Casilla casilla1 = Casilla.CreateInstance(7, 8, 1); //Hardcodeado para prueba
		Casilla casilla2 = Casilla.CreateInstance(7, 9, 1); //Hardcodeado para prueba
		this.AtacarUnaPosicion (casilla1);
		this.AtacarUnaPosicion (casilla2);
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
		Casilla casillaAtaque = Casilla.CreateInstance(0, 0, 1);
		for (int i = casilla1.GetFila (); i < casilla2.GetFila (); i++) {
			for (int j = casilla1.GetColumna (); j < casilla2.GetColumna (); j++) {
				if (area [k] == 1) {
					casillaAtaque.SetFila (casilla1.GetFila () + i);
					casillaAtaque.SetColumna (casilla1.GetColumna () + j);
					this.AtacarUnaPosicion (casillaAtaque);
				}
				k++;
			}
		}
	}

	public void AtacarConProyectilAltamenteExplosivo() { //Recibe solo una posicion e impacta en las 4 cercanas, si es posible
		Casilla casilla = Casilla.CreateInstance(5, 6, 1); //Hardcodeado para prueba, Ataque completo
		Casilla casillaAtaque = Casilla.CreateInstance(0, 0, 1);
		//Casilla casilla = Casilla.CreateInstance(0, 3, 1); //Hardcodeado para prueba, Ataque sin extremo superior
		//Casilla casilla = Casilla.CreateInstance(9, 6, 1); //Hardcodeado para prueba, Ataque sin extremo inferior
		//Casilla casilla = Casilla.CreateInstance(4, 0, 1); //Hardcodeado para prueba, Ataque sin extremo izquierdo
		//Casilla casilla = Casilla.CreateInstance(5, 9, 1); //Hardcodeado para prueba, Ataque sin extremo derecho
		this.AtacarUnaPosicion (casilla);
		if (casilla.GetFila () != 0) {
			casillaAtaque.SetFila (casilla.GetFila () - 1);
			casillaAtaque.SetColumna (casilla.GetColumna ());
			this.AtacarUnaPosicion (casillaAtaque);	
		}
		if (casilla.GetFila () != 9) {
			casillaAtaque.SetFila (casilla.GetFila () + 1);
			casillaAtaque.SetColumna (casilla.GetColumna ());
			this.AtacarUnaPosicion (casillaAtaque);	
		}
		if (casilla.GetColumna () != 0) {
			casillaAtaque.SetFila (casilla.GetFila ());
			casillaAtaque.SetColumna (casilla.GetColumna () - 1);
			this.AtacarUnaPosicion (casillaAtaque);	
		}
		if (casilla.GetColumna () != 9) {
			casillaAtaque.SetFila (casilla.GetFila ());
			casillaAtaque.SetColumna (casilla.GetColumna () + 1);
			this.AtacarUnaPosicion (casillaAtaque);
		}
	}

	public void AtacarConTorpedo () {
		Casilla casilla = Casilla.CreateInstance(0, 8, 1); //Hardcodeado para prueba, le pasariamos directamente una columna
		Casilla casillaAtaque = Casilla.CreateInstance(0, 0, 1);
		//this.tablero [ 2 , casilla.GetColumna ()] = 2; //Hardcodeado para simular que hay un barco en esa posicion
		int posicionFila = 0;
		while (posicionFila < 10 && this.tablero [posicionFila, casilla.GetColumna ()] != 2 ) {
			posicionFila++;
		}
		if (posicionFila == 10) {
			Debug.Log ("No se encontró ningun barco en la columna atacada");
			return;
		}
		casillaAtaque.SetFila (posicionFila);
		casillaAtaque.SetColumna (casilla.GetColumna ());
		if (this.AtacarUnaPosicion (casillaAtaque) == 1) {
			posicionFila++;
			if (posicionFila < 10) {
				casillaAtaque.SetFila (posicionFila);
				this.AtacarUnaPosicion (casillaAtaque);
			}
		}
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
