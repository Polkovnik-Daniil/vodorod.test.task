using Microsoft.EntityFrameworkCore;
using vodorod.test.task.core.Models;
using vodorod.test.task.core.Abstractions;
using System.Text.Json;
using vodorod.test.task.data.access.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace vodorod.test.task.data.access.Repositories
{
    public class RateEntityRepository : IEntityClassesRepository
    {
        private readonly VodorotTestTaskDbContext _context;
        public RateEntityRepository(VodorotTestTaskDbContext context)
        {
            _context = context;
        }
        public async Task<List<RateModel>> Get(DateTime date)
        {
            var Entities = await _context.RateEntity.AsNoTracking().Where(x => x.Date == date).ToListAsync();
            var result = await CheckAndRequestToNationalBank(date, Entities);
            
            var entities = result
                .Select(e => RateModel.Create(e.Id, e.Cur_OfficialRate, e.Cur_Abbreviation, e.Cur_Scale, e.Date).rate)
                .ToList();
            return entities;
        }
        public async Task<List<RateEntity>> CheckAndRequestToNationalBank(DateTime date, List<RateEntity> rateEntities)
        {
            List<RateEntity>? rateEntity = null;
            if (rateEntities.Count == 0)
            {
                var client = new HttpClient() { BaseAddress = new Uri($"https://api.nbrb.by/") };
                var response = await client.GetAsync($"/exrates/rates?ondate={date.Year}-{date.Month}-{date.Day}&periodicity=0");
                var content = await response.Content.ReadAsStringAsync();
                rateEntity = JsonSerializer.Deserialize<List<RateEntity>>(content);
                if (rateEntity != null)
                {
                    rateEntity.ForEach(async x => await _context.RateEntity.AddAsync(x));
                    _context.SaveChangesAsync();
                }
                return rateEntity;
            }
            return rateEntities;
        }
        public async Task<RateModel> Get(DateTime date, string Cur_Abbreviation)
        {
            var Entities = await _context.RateEntity.AsNoTracking().Where(x => x.Date == date & x.Cur_Abbreviation == Cur_Abbreviation).ToListAsync();
            var result = await CheckAndRequestToNationalBank(date, Entities);
            var rateEntity = result.Where(x => x.Cur_Abbreviation == Cur_Abbreviation).First();
            var rateModel = RateModel.Create(rateEntity.Id, rateEntity.Cur_OfficialRate, rateEntity.Cur_Abbreviation, rateEntity.Cur_Scale, rateEntity.Date).rate;
            return rateModel;
        }
        public async Task<Guid> Create(RateModel modelClass)
        {
            var entityClass = new RateEntity();
            await _context.RateEntity.AddAsync(entityClass);
            await _context.SaveChangesAsync();
            return entityClass.Id;
        }
        public async Task<Guid> Update(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime datee)
        {
            await _context.RateEntity
                .Where(b => b.Id == Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Id, b => b.Id)
                    .SetProperty(b => b.Cur_OfficialRate, b => b.Cur_OfficialRate)
                    .SetProperty(b => b.Cur_Abbreviation, b => b.Cur_Abbreviation)
                    .SetProperty(b => b.Cur_Scale, b => b.Cur_Scale)
                    .SetProperty(b => b.Date, b => b.Date)
                    );
            return Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.RateEntity
            .Where(b => b.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
