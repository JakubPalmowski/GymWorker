namespace TrainingAndDietApp.Common.DTOs.User
{
    public class UserDto
    {
        public int Id_user { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Phone_number { get; set; }
        public string Bio { get; set; }
        public int Opinion_number { get; set; }
        public decimal Rate { get; set; }
        public string Role_name { get; set; }
        public decimal? Training_plan_price_from { get; set; }
        public decimal? Training_plan_price_to { get; set; }
        public decimal? Personal_training_price_from { get; set; }
        public decimal? Personal_training_price_to { get; set; }
        public decimal? Diet_price_from { get; set; }
        public decimal? Diet_price_to { get; set; }

    }

}
