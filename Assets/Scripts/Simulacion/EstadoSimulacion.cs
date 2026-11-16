// Las etapas por las que pasa la simulación, de principio a fin.
public enum EstadoSimulacion
{
    Inicio,      // Pantalla de bienvenida: el jugador todavía no se mueve
    Normal,      // Se puede caminar; todavía no hay emergencia
    Emergencia,  // Sonó la alarma: corre el reloj
    Exito,       // Llegó a la zona segura a tiempo
    Fracaso      // Se acabó el tiempo o respiró demasiado humo
}
