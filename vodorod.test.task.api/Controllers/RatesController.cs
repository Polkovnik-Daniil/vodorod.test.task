using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vodorod.test.task.core.Abstractions;
using vodorod.test.task.api.Contracts;


namespace vodorod.test.task.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IModelsService _modelsService;
        public RatesController(IModelsService modelsService)
        {
            _modelsService = modelsService;
        }
        /// <summary>
        /// Метод для обработки запроса всех валют конкретной даты
        /// </summary>
        /// <param name="date">Дата получения актуальной информации</param>
        /// <returns></returns>
        [HttpGet("{date}")]
        public async Task<ActionResult<List<RatesResponse>>> GetModels(DateTime date)
        {
            var entities = await _modelsService.GetAllEntities(date);
            var ratesResponses = entities.Select(e => new RatesResponse(e.Id, e.Cur_OfficialRate, e.Cur_Abbreviation, e.Cur_Scale, e.Date));
            return Ok(ratesResponses);
        }
        /// <summary>
        /// Метод для обработки запроса валюты конкретной даты
        /// </summary>
        /// <param name="date">Дата получения актуальной информации</param>
        /// <param name="Cur_Abbreviation">Аббревиатура валюты</param>
        /// <returns></returns>
        [HttpGet("/{date}/{Cur_Abbreviation}")]
        public async Task<ActionResult<List<RatesResponse>>> GetModel(DateTime date, string Cur_Abbreviation)
        {
            var entities = await _modelsService.GetEntity(date, Cur_Abbreviation);
            var response = new RatesResponse(entities.Id, entities.Cur_OfficialRate, entities.Cur_Abbreviation, entities.Cur_Scale, entities.Date);
            return Ok(response);
        }
    }
}
