namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public class ReducedAction:AbstractActionFunction {
        static string _tokenReduced;
        static string [] _ruled;
        public ReducedAction( string tokenReduced, string [] tokensRule)
        {
            Action = ActionEnum.REDUCCION;
            _tokenReduced = tokenReduced;
            _ruled = tokensRule;
        }
        public static string ReduceTokens( string [] tokensToAnalice ) {
            return ComparedTokens(tokensToAnalice) ? _tokenReduced : string.Empty;
        }
        public static bool ComparedTokens( string [] tokensRecived ) {
            int count = 0;
            for ( int i = 0 ; i < _ruled.Length ; i++ ) {
                count = (_ruled [i] == tokensRecived [i]) ? count++ : count;
            }
            return count.Equals(_ruled.Length);
        }
    }
}
