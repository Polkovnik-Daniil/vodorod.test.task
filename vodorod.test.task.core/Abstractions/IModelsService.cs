using vodorod.test.task.core.Models;

namespace vodorod.test.task.core.Abstractions
{
    public interface IModelsService
    {
        Task<Guid> CreateEntity(RateModel rateModel);
        Task<Guid> DeleteEntity(Guid id);
        Task<List<RateModel>> GetAllEntities(DateTime dateTime);
        Task<RateModel> GetEntity(DateTime dateTime, string Cur_Abbrreviation);
        Task<Guid> UpdateEntity(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date);

    }
}