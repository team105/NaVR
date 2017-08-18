using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorPartida : MonoBehaviour {
	private Tablero tablero;
	private Habilidad habilidad;

	public void InicializarPartida () {
		tablero = Tablero.CreateInstance (1);
		habilidad = Habilidad.CreateInstance ();
		Debug.Log(tablero.GetLongitud ());
	}

	public void MostrarContenidoTablero () {
		int filaLength = 10;
		for (int i = 0; i < filaLength; i++) {
			print (this.tablero.GetEstadoCasilla (i,0) + "" + this.tablero.GetEstadoCasilla (i,1) + "" + this.tablero.GetEstadoCasilla (i,2) + 
				"" + this.tablero.GetEstadoCasilla (i,3) + "" + this.tablero.GetEstadoCasilla (i,4) + "" + 
				this.tablero.GetEstadoCasilla (i,5) + "" + this.tablero.GetEstadoCasilla (i,6) + "" + 
				this.tablero.GetEstadoCasilla (i,7) + "" + this.tablero.GetEstadoCasilla (i,8) + "" + this.tablero.GetEstadoCasilla (i,9));
		}
	}
		
	public void AtacarUnaPosicion () {
		habilidad.AtacarUnaPosicion (this.tablero);
	}
	public void AtacarDosPosiciones () {
		habilidad.AtacarDosPosiciones (this.tablero);
	}

	public void AtacarConArtilleriaRapida () {
		habilidad.AtacarConArtilleriaRapida (this.tablero);
	}

	public void AtacarConProyectilAltamenteExplosivo () {
		habilidad.AtacarConProyectilAltamenteExplosivo (this.tablero);
	}

	public void AtacarConTorpedo () {
		habilidad.AtacarConTorpedo (this.tablero);
	}

	public Tablero GetTablero () {
		return this.tablero;
	}
}
