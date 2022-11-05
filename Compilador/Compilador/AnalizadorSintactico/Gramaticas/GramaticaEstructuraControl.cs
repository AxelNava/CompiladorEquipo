using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
    public class GramaticaEstructuraControl : AbstractAnalisisTable
    {
        public enum notTerminalsForThis
        {
            ESTRUCTURACONTROL,
            IF,
            WHILE,
            FOR,
            DO

        }

        private static readonly string[] notTerminalSymbols =
        {
            "<estructuracontrol>",
            "if",
            "while",
            "for",
            "do"
        };
        public GramaticaEstructuraControl()
        {
            tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
            {
                {


                   0, new Dictionary<string, AbstractActionFunction>()
                   {
                       {tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2) },

                   }
                },
                 {


                   1, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"if", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 2) },

                   }
                },
            };
        }
    }

   
}
