using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
namespace Compilador.Gramaticas {
    public class GramaticaCondicion : AbstractAnalisisTable {
        ReducedAction OperadorAND_LogicToken = new ReducedAction("OperadorLog", new string [] { "AND" });
        ReducedAction OperadorOR_LogicToken = new ReducedAction("OperadorLog", new string [] { "OR" });
        ReducedAction Comp_compareToken = new ReducedAction("Comp", new string [] { "Valor", "Comparador", "Valor" });
        ReducedAction Valor_enteroToken = new ReducedAction("Valor", new string [] { "Entero" });
        ReducedAction Valor_decimalToken = new ReducedAction("Valor", new string [] { "Decimal" });
        ReducedAction Valor_cadenaToken = new ReducedAction("Valor", new string [] { "Cadena" });
        ReducedAction Valor_charToken = new ReducedAction("Valor", new string [] { "Caracter" });
        ReducedAction Valor_metodoToken = new ReducedAction("Valor", new string [] { "Metodo" });
        
        public GramaticaCondicion() {
            tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>() {
                {0,new Dictionary<string, AbstractActionFunction>(){
                     {"bool", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)},
                    {"NEG", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO,4)},
                    {"Identificador", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)},
                    {"Int", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)},
                    {"Decimal", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)},
                    {"String", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)},
                    {"Metodo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)},
                    {"Char", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)},
                    {"Condicion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)},
                    {"Valor", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)},
                    {"Comparacion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)}
                } },
                {1, new Dictionary<string, AbstractActionFunction>() {
                    {"FinCadena",new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 1)
                    }
                }
                },
                {2, new Dictionary<string, AbstractActionFunction>(){
                    {"AND", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15) },
                    {"OR", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16) },
                    {"LAMBDA", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14) },
                    {"Recurs", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12) },
                    {"OperaLog", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13) }                   
                } },
                {3,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15) },
                    {"OR", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16) },
                    {"LAMBDA", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14) },
                    {"Recurs", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 17) },
                    {"OperaLog", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13) }
                } },
                {4,new Dictionary<string, AbstractActionFunction>(){
                    {"Bool", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18) }
                } },
                {5,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)}} 
                },
                {6,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Identificador"})}}
                },
                {7,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Int"})}}
                },
                {8,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Decimal"})}}
                },
                {9,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Cadena"})}}
                },
                {10,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Metodo"})}}
                },
                {11,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[]{"Caracter"})}}
                },
                {12,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Condi", new string[]{"OperaLog","Recurs"})}} 
                },
                {13,new Dictionary<string, AbstractActionFunction>(){
                    {"BOOL", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3) },
                    {"Negacion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO,4) },
                    {"Identificador", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20) },
                    {"ENTERO", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 21) },
                    {"Decimal", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22) },
                    {"Cadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23) },                    
                    {"Metodo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24) },
                    {"Caracter", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25) },
                    {"Condicion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 27) },
                    {"Valor", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5) },
                    {"Comp", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 28) },
                    
                } },
                {14,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Recurs", new string[]{"Lambda"})}
                }
                },
                {15,new Dictionary<string, AbstractActionFunction>(){
                    {"BOOL", OperadorAND_LogicToken},
                    {"Negacion", OperadorAND_LogicToken },
                    {"Identificador", OperadorAND_LogicToken },
                    {"Entero", OperadorAND_LogicToken },
                    {"Decimal", OperadorAND_LogicToken },
                    {"Cadena", OperadorAND_LogicToken },
                    {"Metodo", OperadorAND_LogicToken },
                    {"Caracter", OperadorAND_LogicToken }
                }
                },
                {16,new Dictionary<string, AbstractActionFunction>(){
                   {"BOOL", OperadorOR_LogicToken},
                    {"Negacion", OperadorOR_LogicToken },
                    {"Identificador", OperadorOR_LogicToken },
                    {"Entero", OperadorOR_LogicToken },
                    {"Decimal", OperadorOR_LogicToken },
                    {"Cadena", OperadorOR_LogicToken },
                    {"Metodo", OperadorOR_LogicToken },
                    {"Caracter", OperadorOR_LogicToken }
                } 
                },
                {17,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Condicion", new string[]{"BOOL","Recurs"}) }
                } },
                {18,new Dictionary<string, AbstractActionFunction>(){
                    {"Negacion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)},
                    {"AND", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)},
                    {"OR", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)},
                    {"Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)},
                    {"Recurs", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 36) },
                    {"OperadorLog", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13) }
                }
                },
                {19,new Dictionary<string, AbstractActionFunction>(){
                    {"Identificador", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30)},
                    {"Entero", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31)},
                    {"Decimal", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 32)},
                    {"Cadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)},
                    {"Metodo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 35)},
                    {"Caracter", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 34)},
                    {"Valor", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 26)}
                } 
                },
                {20,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Identificador"})}
                } 
                },
                {21,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Entero"})}
                } },
                {22,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Decimal"})}
                } },
                {23,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Cadena"})}
                } },
                {24,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Caracter"})}
                } },
                {25,new Dictionary<string, AbstractActionFunction>(){
                    {"Comparador", new ReducedAction("Valor", new string[] {"Metodo"})}
                } },
                {26,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", Comp_compareToken},
                    {"OR", Comp_compareToken},
                    {"Lamda", Comp_compareToken}                    
                } },
                {27,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Recurs", new string[]{"OperadorLog", "Condicion"}) }
                }
                },
                {28,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15) },
                    {"OR", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16) },
                    {"Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14) },
                    {"Recurs", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 29) },
                    {"OperadorLog", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13 )}
                } },
                {29,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Recurs", new string[]{"Comp", "Recurs"}) }
                } },
                {30,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", new ReducedAction("Valor", new string[]{"Identificador"}) },
                    {"OR", new ReducedAction("Valor", new string[]{"Identificador"}) },
                    {"Lamda", new ReducedAction("Valor", new string[]{"Idenficador"}) }
                } },
                {31,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", Valor_enteroToken },
                    {"OR", Valor_cadenaToken },
                    {"Lambda", Valor_cadenaToken }
                } },
                {32,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", Valor_decimalToken },
                    {"OR", Valor_decimalToken },
                    {"Lambda", Valor_decimalToken }
                } },
                {33,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", Valor_cadenaToken },
                    {"OR", Valor_cadenaToken },
                    {"Lambda", Valor_cadenaToken }
                } },
                {34,new Dictionary<string, AbstractActionFunction>(){
                    {"AND", Valor_charToken },
                    {"OR", Valor_charToken },
                    {"Lambda", Valor_charToken }
                } },
                {35,new Dictionary<string, AbstractActionFunction>(){
                   {"AND", Valor_metodoToken },
                    {"OR", Valor_metodoToken },
                    {"Lambda", Valor_metodoToken }
                } },
                {36,new Dictionary<string, AbstractActionFunction>(){
                    {"FinCadena", new ReducedAction("Condicion", new string[] {"Negacion", "BOOL", "Recurs"}) }
                } }
            };
        }
        public void EjecutarAnalisis() {

        }
    }
}
