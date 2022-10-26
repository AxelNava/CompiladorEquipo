namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public abstract class AbstractActionFunction {
        private ActionEnum action;
        public enum ActionEnum {
            DESPLAZAMIENTO,
            GOTO,
            ACEPTACION,
            REDUCCION
        }
        public ActionEnum Action { get => action; set => action = value; }
    }
}
