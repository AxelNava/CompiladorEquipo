namespace Compilador {
    public static class VariablesGlobalesAutomatas {
        private static int _lastIndexFound;
        public static int LastIndexFound { get => _lastIndexFound; set => _lastIndexFound = value; }

        private static char [] _charCodeText;
        public static char [] CharCodeText { get => _charCodeText; set => _charCodeText = value; }

        private static int _lengthText;
        public static int LengthText { get => _lengthText; set => _lengthText = CharCodeText.Length; }

        private static int _countLines;
        public static int CountLines { get => _countLines; set => _countLines = value; }
    }
}