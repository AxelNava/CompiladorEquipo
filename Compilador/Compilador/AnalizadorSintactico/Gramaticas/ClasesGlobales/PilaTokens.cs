using System;
using System.Collections.Generic;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales {
    public class PilaTokens {
        static Stack<string> _globalTokens = new Stack<string>();
        public static Stack<string> GlobalTokens { get => _globalTokens; set => _globalTokens = value; }
        public static List<Tuple<int, string>> numLineToken = new List<Tuple<int, string>>();
    }
}
