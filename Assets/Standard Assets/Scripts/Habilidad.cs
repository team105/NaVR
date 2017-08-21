using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constantes {
	public const int TODAVIA_NO_ATACADO = 0;
	public const int YA_ATACADO_AGUA = 1;
	public const int YA_ATACADO_BARCO = 2;
}

public class Habilidad : ScriptableObject {

	public void Init () {
	//Cuando le definamos atributos seguramente esto tenga mas sentido	
	}

	public static Habilidad CreateInstance()
	{
		var data = ScriptableObject.CreateInstance<Habilidad>();
		data.Init();
		return data;
	}

	public int AtacarUnaPosicion (Tablero tableroAtaque, Tablero tableroPosicion, Casilla casilla = null) {	//Cuando lo hagamos funcionar deberia recibir de parametro un objeto Casilla 
		//casilla = Casilla.CreateInstance(3, 4, 1); //Hardcodeado para prueba, descomentar para probar este ataque
		int fila = casilla.GetFila ();
		int columna = casilla.GetColumna ();
		if (tableroPosicion.GetHayBarco (fila, columna) == true) {
			tableroAtaque.SetEstadoCasilla (fila, columna, Constantes.YA_ATACADO_BARCO); //Ataque exitoso a un barco
			return 1;
		}
		else if (tableroPosicion.GetHayBarco (fila, columna) == false) {
			tableroAtaque.SetEstadoCasilla (fila, columna, Constantes.YA_ATACADO_AGUA); //Ataque fallido que impacto en agua
			return 0;
		}
		return -1;
	}

	public void AtacarDosPosiciones (Tablero tableroAtaque, Tablero tableroPosicion) { //Cuando lo hagamos funcionar deberia recibir de parametro dos objetos Casilla
		Casilla casilla1 = tableroPosicion.GetCasilla (7,8); //Hardcodeado para prueba
		Casilla casilla2 = tableroPosicion.GetCasilla (7,9); //Hardcodeado para prueba
		this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casilla1);
		this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casilla2);
	}

	public void AtacarConArtilleriaRapida (Tablero tableroAtaque, Tablero tableroPosicion) { //Podriamos recibir las dos casillas de las puntas y usar columnas y filas para calcular el area
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
					this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);
				}
				k++;
			}
		}
	}

	public void AtacarConProyectilAltamenteExplosivo(Tablero tableroAtaque, Tablero tableroPosicion) { //Recibe solo una posicion e impacta en las 4 cercanas, si es posible
		Casilla casilla = Casilla.CreateInstance(5, 6, 1); //Hardcodeado para prueba, Ataque completo
		Casilla casillaAtaque = Casilla.CreateInstance(0, 0, 1);
		//Casilla casilla = Casilla.CreateInstance(0, 3, 1); //Hardcodeado para prueba, Ataque sin extremo superior
		//Casilla casilla = Casilla.CreateInstance(9, 6, 1); //Hardcodeado para prueba, Ataque sin extremo inferior
		//Casilla casilla = Casilla.CreateInstance(4, 0, 1); //Hardcodeado para prueba, Ataque sin extremo izquierdo
		//Casilla casilla = Casilla.CreateInstance(5, 9, 1); //Hardcodeado para prueba, Ataque sin extremo derecho
		this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casilla);
		if (casilla.GetFila () != 0) {
			casillaAtaque.SetFila (casilla.GetFila () - 1);
			casillaAtaque.SetColumna (casilla.GetColumna ());
			this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);	
		}
		if (casilla.GetFila () != 9) {
			casillaAtaque.SetFila (casilla.GetFila () + 1);
			casillaAtaque.SetColumna (casilla.GetColumna ());
			this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);	
		}
		if (casilla.GetColumna () != 0) {
			casillaAtaque.SetFila (casilla.GetFila ());
			casillaAtaque.SetColumna (casilla.GetColumna () - 1);
			this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);	
		}
		if (casilla.GetColumna () != 9) {
			casillaAtaque.SetFila (casilla.GetFila ());
			casillaAtaque.SetColumna (casilla.GetColumna () + 1);
			this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);
		}
	}

	public void AtacarConTorpedo (Tablero tableroAtaque, Tablero tableroPosicion) {
		Casilla casilla = Casilla.CreateInstance(0, 8, 1); //Hardcodeado para prueba, le pasariamos directamente una columna
		Casilla casillaAtaque = Casilla.CreateInstance(0, 0, 1);
		//this.tablero [ 2 , casilla.GetColumna ()] = 2; //Hardcodeado para simular que hay un barco en esa posicion
		int posicionFila = 0;
		while (posicionFila < 10 && tableroPosicion.GetEstadoCasilla (posicionFila, casilla.GetColumna ()) != 2 ) {
			posicionFila++;
		}
		if (posicionFila == 10) {
			Debug.Log ("No se encontró ningun barco en la columna atacada");
			return;
		}
		casillaAtaque.SetFila (posicionFila);
		casillaAtaque.SetColumna (casilla.GetColumna ());
		if (this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque) == 1) {
			posicionFila++;
			if (posicionFila < 10) {
				casillaAtaque.SetFila (posicionFila);
				this.AtacarUnaPosicion (tableroAtaque, tableroPosicion, casillaAtaque);
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

	public void CrearBarcoFantasma (Tablero tableroPosicion, Barco barcoFantasma) {
		Casilla[] posicionesOcupadas = barcoFantasma.GetPosicionesOcupadas ();
		for (int i=0; i<posicionesOcupadas.Length; i++) {
			tableroPosicion.SetHayBarcoFantasma (posicionesOcupadas[i].GetFila (), posicionesOcupadas[i].GetColumna (), true);
		}
	}

	public void ReforzarArmadura (Tablero tableroPosicion) {
		if (tableroPosicion.GetHayCasillaReforzada (0, 0) != true) { //Deberia hacer un GetFila y GetColumna de la casilla
			tableroPosicion.SetHayCasillaReforzada (0, 0, true); //Deberia hacerlo sobre un GetFila y GetColumna de la casilla
		}
	}

}
