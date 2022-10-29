namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public class ReducedAction:AbstractActionFunction {
        private string _tokenReduced;
        public string [] _ruled { get;}
        public ReducedAction( string tokenReduced, string [] tokensRule)
        {
            Action = ActionEnum.REDUCCION;
            _tokenReduced = tokenReduced;
            _ruled = tokensRule;
        }
        /// <summary>
        /// This method return the rule of production of the grammar
        /// </summary>
        /// <param name="tokensToAnalice">The sequence of the tokens received</param>
        /// <returns>The token producer</returns>
        public string ReduceTokens( string [] tokensToAnalice ) {
            return ComparedTokens(tokensToAnalice) ? _tokenReduced : string.Empty;
        }
        private bool ComparedTokens( string [] tokensRecived ) {
            int count = 0;
            for ( int i = 0 ; i < _ruled.Length ; i++ ) {
                count = (_ruled [i] == tokensRecived [i]) ? ++count : count;
            }
            return count.Equals(_ruled.Length);
        }
    }
}
