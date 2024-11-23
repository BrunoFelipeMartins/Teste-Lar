namespace WebApiLar.Domain.Entity.Enum
{
    public static class Active
    {
        public const string ACTIVE = "active";
        public const string INACTIVE = "inactive";

        public static string getByText(string text){
            switch (text.ToLower()){
                case "active":
                    return ACTIVE;
                case "inactive":
                    return INACTIVE;
                default:
                    return "Error";
                
            }
        }
    }
}