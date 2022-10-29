namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public class AccionFuncion_TablaAnalisis: AbstractActionFunction {
        public int _state { get; set; }
        public AccionFuncion_TablaAnalisis(ActionEnum action, int state) {
            Action = action;
            _state = state;
        }
    }
}
