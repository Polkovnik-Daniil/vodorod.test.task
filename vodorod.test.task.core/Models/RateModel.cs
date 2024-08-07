
namespace vodorod.test.task.core.Models
{
    //EntityClass
    public class RateModel(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date)
    {
        public Guid Id { get; set; } = Id;
        //"Cur_OfficialRate": 3.2945
        public decimal Cur_OfficialRate { get; set; } = Cur_OfficialRate;
        //"Cur_Abbreviation": "GBP",
        public string Cur_Abbreviation { get; set; } = Cur_Abbreviation;
        //"Cur_Scale": 1,
        public int Cur_Scale { get; set; } = Cur_Scale;
        //"Date": "2023-01-10T00:00:00",
        public DateTime Date { get; set; } = date;
        public const int MAX_LENGTH = 3;
        public static (RateModel rate, string Error) Create(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(Cur_Abbreviation))
            {
                error = "Cur_Abbreviation is empty!";
            }
            RateModel rate = new RateModel(Id, Cur_OfficialRate, Cur_Abbreviation, Cur_Scale, date);
            return (rate, error);
        }
    }
}
