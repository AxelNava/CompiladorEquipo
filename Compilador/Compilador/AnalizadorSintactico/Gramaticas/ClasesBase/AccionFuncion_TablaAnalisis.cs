namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public class AccionFuncion_TablaAnalisis: AbstractActionFunction {
        protected int state { get; set; }
        public AccionFuncion_TablaAnalisis(ActionEnum action, int state) {
            Action = action;
            this.state = state;
        }
    }
}
