using System.Collections.Generic;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public abstract class AbstractAnalisisTable {
        public Stack<int []> pilaDeInstruccionesVerificacion { get; set; }
        public Dictionary<int, Dictionary<string, AbstractActionFunction>> tablaAnalisis { get; set; }
    }
}
