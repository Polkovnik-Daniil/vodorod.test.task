
using vodorod.test.task.core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace vodorod.test.task.core.Abstractions
{
    public interface IEntityClassesRepository
    {
        Task<Guid> Create(RateModel rateModel);
        Task<Guid> Delete(Guid id);
        Task<List<RateModel>> Get(DateTime date);
        Task<RateModel> Get(DateTime date, string Cur_Abbreviation);
        Task<Guid> Update(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date);
    }
}