namespace MyUI.Enum
{ 
    public static class StringFormat
    {      
        public static string moneyString = "{0:#,##0.00}";
        public static string consumoString = "{0:#,##0.0}";
        public static string moneyString8 = "{0:#,##0.00000000}";
        public static string moneyStringForExcel = "#,##0.00";
        public static int cantidadLugaresDespuesComa = 8;
        public static string porcientoString = "{0:#,0.##'%';;'0.00%'}";
        public static string fechaCortaString = "yyyy-MM-dd";
        public static string fechaLargaString = "yyyy-MM-dd HH:mm:ss";
        public static string fechaCortaStringDMY = "d-MM-yyyy";
        public static string fechaLargaStringDMY = "d-MM-yyyy HH:mm:ss";
    }
}
