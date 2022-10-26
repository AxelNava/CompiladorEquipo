
namespace Compilador {
    public class Mensajes {
        private static string _errorMessages;
        public static string ErrorMessages { get { return _errorMessages; } set { _errorMessages = value; } }
        public static void CleanMessages() {
            ErrorMessages = string.Empty;
        }
    }

    public class prueba
    {
        public prueba()
        {
            
        }
    }
}
