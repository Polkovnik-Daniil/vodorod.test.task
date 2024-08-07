using System.ComponentModel.DataAnnotations.Schema;

namespace vodorod.test.task.data.access.Entities
{
    public class RateEntity
    {
        public Guid Id { get; set; }
        //"Cur_OfficialRate": 3.2945
        public decimal Cur_OfficialRate { get; set; }
        //"Cur_Abbreviation": "GBP",
        public string Cur_Abbreviation { get; set; }
        //"Cur_Scale": 1,
        public int Cur_Scale { get; set; }
        //"Date": "2023-01-10T00:00:00",
        [Column(TypeName = "timestamp(6)")]
        public DateTime Date { get; set; }
    }
}
    