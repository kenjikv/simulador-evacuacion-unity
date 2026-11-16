// Contrato: todo lo que el jugador puede usar con la tecla E cumple estas cuatro reglas.
public interface IInteractuable
{
    string TextoIndicacion { get; }   // Lo que se lee en pantalla, por ejemplo "E: Usar interruptor"
    bool PuedeInteractuar { get; }     // false mientras el objeto está bloqueado
    string MotivoBloqueo { get; }      // Lo que se lee si está bloqueado
    void Interactuar();                // Lo que pasa al pulsar E
}
