namespace WebApiLar.Domain.Entity.Enum
{
    public static class TypeTelephone
    {
        public const string RESIDENTIAL = "residencial";
        public const string COMMERCIAL = "comercial";
        public const string CELLPHONE = "celular";

        public static string getByText(string text){
            switch (text.ToLower()){
                case "residencial":
                    return RESIDENTIAL;
                case "comercial":
                    return COMMERCIAL;
                    case "celular":
                    return CELLPHONE;
                default:
                    return "Error";
                
            }
        }
    }
}