using vodorod.test.task.core.Abstractions;
using vodorod.test.task.core.Models;


namespace vodorod.test.task.application.Services
{
    public class RatesService : IModelsService
    {
        private readonly IEntityClassesRepository _entityClassesRepository;
        public RatesService(IEntityClassesRepository entityClassesRepository)
        {
            _entityClassesRepository = entityClassesRepository;
        }
        public async Task<List<RateModel>> GetAllEntities(DateTime dateTime)
        {
            return await _entityClassesRepository.Get(dateTime);
        }
        public async Task<RateModel> GetEntity(DateTime dateTime, string Cur_Abbrreviation)
        {
            return await _entityClassesRepository.Get(dateTime, Cur_Abbrreviation);
        }

        public async Task<Guid> CreateEntity(RateModel modelClass)
        {
            return await _entityClassesRepository.Create(modelClass);
        }

        public async Task<Guid> UpdateEntity(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date)
        {
            return await _entityClassesRepository.Update(Id, Cur_OfficialRate, Cur_Abbreviation, Cur_Scale, date);
        }
        public async Task<Guid> DeleteEntity(Guid id)
        {
            return await _entityClassesRepository.Delete(id);
        }
    }
}
