using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorPartida : MonoBehaviour {
	private Tablero tableroAtaque;
	private Tablero tableroPosicion;
	private Habilidad habilidad;

	public void InicializarPartida () {
		tableroAtaque = Tablero.CreateInstance (1);
		Barco [] barcos = this.CrearBarcosParaPruebas (); //Solo para pruebas
		tableroPosicion = Tablero.CreateInstance (2, barcos); //Para inicializar el tablero posiciones tenemos q mandarle un array de barcos
		habilidad = Habilidad.CreateInstance ();
		Debug.Log(tableroAtaque.GetLongitud ());
	}

	public void MostrarContenidoTablero (Tablero tablero, int tipo) { //Para pruebas
		int filaLength = 10;
		if (tipo == 1) {
			for (int i = 0; i < filaLength; i++) {
				print (tablero.GetEstadoCasilla (i, 0) + " " + tablero.GetEstadoCasilla (i, 1) + " " + tablero.GetEstadoCasilla (i, 2) +
				" " + tablero.GetEstadoCasilla (i, 3) + " " + tablero.GetEstadoCasilla (i, 4) + " " +
				tablero.GetEstadoCasilla (i, 5) + " " + tablero.GetEstadoCasilla (i, 6) + " " +
				tablero.GetEstadoCasilla (i, 7) + " " + tablero.GetEstadoCasilla (i, 8) + " " + tablero.GetEstadoCasilla (i, 9));
			}
		}
		if (tipo == 2) {
			for (int i = 0; i < filaLength; i++) {
				print (tablero.GetHayBarco (i,0) + " " + tablero.GetHayBarco (i,1) + " " + tablero.GetHayBarco (i,2) + 
					" " + tablero.GetHayBarco (i,3) + " " + tablero.GetHayBarco (i,4) + " " + 
					tablero.GetHayBarco (i,5) + " " + tablero.GetHayBarco (i,6) + " " + 
					tablero.GetHayBarco (i,7) + " " + tablero.GetHayBarco (i,8) + " " + tablero.GetHayBarco (i,9));
			}
		}
		if (tipo == 3) {
			for (int i = 0; i < filaLength; i++) {
				print (tablero.GetHayCasillaReforzada (i,0) + " " + tablero.GetHayCasillaReforzada (i,1) + " " + tablero.GetHayCasillaReforzada (i,2) + 
					" " + tablero.GetHayCasillaReforzada (i,3) + " " + tablero.GetHayCasillaReforzada (i,4) + " " + 
					tablero.GetHayCasillaReforzada (i,5) + " " + tablero.GetHayCasillaReforzada (i,6) + " " + 
					tablero.GetHayCasillaReforzada (i,7) + " " + tablero.GetHayCasillaReforzada (i,8) + " " + tablero.GetHayCasillaReforzada (i,9));
			}
		}
		if (tipo == 4) {
			for (int i = 0; i < filaLength; i++) {
				print (tablero.GetHayBarcoFantasma (i,0) + " " + tablero.GetHayBarcoFantasma (i,1) + " " + tablero.GetHayBarcoFantasma (i,2) + 
					" " + tablero.GetHayBarcoFantasma (i,3) + " " + tablero.GetHayBarcoFantasma (i,4) + " " + 
					tablero.GetHayBarcoFantasma (i,5) + " " + tablero.GetHayBarcoFantasma (i,6) + " " + 
					tablero.GetHayBarcoFantasma (i,7) + " " + tablero.GetHayBarcoFantasma (i,8) + " " + tablero.GetHayBarcoFantasma (i,9));
			}
		}
	}

	public void MostrarContenidoTableroAtaque () { //Para pruebas
		this.MostrarContenidoTablero (this.tableroAtaque, 1);
	}

	public void MostrarContenidoTableroPosicion () { //Para pruebas
		this.MostrarContenidoTablero (this.tableroPosicion, 2); //Muestra hayBarco
		//this.MostrarContenidoTablero (this.tableroPosicion, 3); //Muestra hayCasillaReforzada
		//this.MostrarContenidoTablero (this.tableroPosicion, 4); //Muestra hayBarcoFantasma
	}
		
	public Barco[] CrearBarcosParaPruebas () { //Para pruebas
		Barco[] barcos = new Barco[4];
		Casilla[] posicionesBarco;

		posicionesBarco = new Casilla[3];
		posicionesBarco[0] = Casilla.CreateInstance(7, 7, 1); //Para pruebas
		posicionesBarco[1] = Casilla.CreateInstance(7, 8, 1); //Para pruebas
		posicionesBarco[2] = Casilla.CreateInstance(7, 9, 1); //Para pruebas
		barcos[0] = Barco.CreateInstance(posicionesBarco, 1);

		posicionesBarco = new Casilla[2];
		posicionesBarco[0] = Casilla.CreateInstance(0, 5, 1); //Para pruebas
		posicionesBarco[1] = Casilla.CreateInstance(0, 6, 1); //Para pruebas
		barcos[1] = Barco.CreateInstance(posicionesBarco, 2);

		posicionesBarco = new Casilla[2];
		posicionesBarco[0] = Casilla.CreateInstance(3, 0, 1); //Para pruebas
		posicionesBarco[1] = Casilla.CreateInstance(4, 0, 1); //Para pruebas
		barcos[2] = Barco.CreateInstance(posicionesBarco, 2);

		posicionesBarco = new Casilla[3];
		posicionesBarco[0] = Casilla.CreateInstance(9, 0, 1); //Para pruebas
		posicionesBarco[1] = Casilla.CreateInstance(9, 1, 1); //Para pruebas
		posicionesBarco[2] = Casilla.CreateInstance(9, 2, 1); //Para pruebas
		barcos[3] = Barco.CreateInstance(posicionesBarco, 1);

		return barcos;
	}

	//La idea de las habilidades de ATAQUE es que en el turno del jugador1 se envie como parametro
	//el tableroAtaque del jugador1, y el tableroPosicion del jugador2
	//Para las habilidades de NO ATAQUE se envia por parametro el tableroPosicion del jugador1

	public void AtacarUnaPosicion () { //Deberia recibir de parametro la posicion a atacar
		habilidad.AtacarUnaPosicion (this.tableroAtaque, this.tableroPosicion); //Deberia tambien enviar la posicion a atacar
		//Validacion y disparar animacion.
	}
	public void AtacarDosPosiciones () { //Deberia recibir de parametro las dos posiciones consecutivas a atacar
		habilidad.AtacarDosPosiciones (this.tableroAtaque, this.tableroPosicion); //Deberia tambien enviar las dos posiciones consecutivas a atacar
		//Validacion y disparar animacion.
	}

	public void AtacarConArtilleriaRapida () { //Deberia recibir de parametro la posicion a atacar
		habilidad.AtacarConArtilleriaRapida (this.tableroAtaque, this.tableroPosicion); //Deberia tambien enviar la posicion a atacar
		//Validacion y disparar animacion.
	}

	public void AtacarConProyectilAltamenteExplosivo () { //Deberia recibir de parametro la posicion a atacar
		habilidad.AtacarConProyectilAltamenteExplosivo (this.tableroAtaque, this.tableroPosicion); //Deberia tambien enviar la posicion a atacar
		//Validacion y disparar animacion.
	}

	public void AtacarConTorpedo () { //Deberia recibir de parametro la columna a atacar
		habilidad.AtacarConTorpedo (this.tableroAtaque, this.tableroPosicion); //Deberia tambien enviar la columna a atacar
		//Validacion y disparar animacion.
	}

	public void CrearBarcoFantasma () { //Deberia recibir de parametro las posiciones del barco fantasma
		Casilla [] posicionesBarcoFantasma = new Casilla[3];
		posicionesBarcoFantasma[0] = Casilla.CreateInstance(7, 7, 1); //Para pruebas
		posicionesBarcoFantasma[1] = Casilla.CreateInstance(8, 7, 1); //Para pruebas
		posicionesBarcoFantasma[2] = Casilla.CreateInstance(9, 7, 1); //Para pruebas
		int tipo = 1; //Ultra hardcodeadisimo
		Barco barcoFantasma = Barco.CreateInstance(posicionesBarcoFantasma, tipo);
		habilidad.CrearBarcoFantasma (this.tableroPosicion, barcoFantasma);
	}

	public void ReforzarArmadura () { //Deberia recibir de parametro la posicion de un barco aliado a reforzar
		habilidad.ReforzarArmadura (this.tableroPosicion); //Deberia tambien enviar la posicion de un barco aliado a reforzar
	}

	public Tablero GetTableroAtaque () {
		return this.tableroAtaque;
	}

	public Tablero GetTableroPosicion () {
		return this.tableroPosicion;
	}
}
