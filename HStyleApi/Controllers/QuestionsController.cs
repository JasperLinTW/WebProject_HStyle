using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private QuestionService _service;
		public QuestionsController(AppDbContext db)
		{
			_service = new QuestionService(db);
		}

		// GET: api/<QuestionsController>
		// 得到所有常見問題
		[HttpGet("/CommonQ")]
		public async Task< IEnumerable<CommonQuestionDTO>> GetCommonQuestion()
		{
			return await _service.GetCommonQuestion();
		}

		// GET api/<QuestionsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<QuestionsController>
		// 傳送顧客提的問題(新增資料)
		[HttpPost("/CustomerQ")]
		public void PostCustomerQuestion([FromBody] CustomerQuestionDTO dto)
		{
			_service.PostCustomerQuestion(dto);
		}

		// PUT api/<QuestionsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<QuestionsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
