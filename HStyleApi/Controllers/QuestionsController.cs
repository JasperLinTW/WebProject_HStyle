using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private QuestionService _service;
		private readonly int _member_id;
		public QuestionsController(AppDbContext db)
		{
			_service = new QuestionService(db);
			_member_id = 1; //之後用Cookie取
		}

		// 得到所有常見問題
		[HttpGet("/CommonQ")]
		public async Task<IEnumerable<CommonQuestionDTO>> GetCommonQuestion([FromQuery] string? keyword)
		{
			return await _service.GetCommonQuestion(keyword);
		}

		// 得到所有問題類別
		[HttpGet("/CommonQCategory")]
		public async Task<IEnumerable<QuestionCategoryDTO>> GetQuestionCategory()
		{
			return await _service.GetQuestionCategory();
		}

		// 得到會員的問題
		[HttpGet("/MemberQResponse")]//此行與上一支api衝突，修改名稱
		public async Task<IEnumerable<MemberResponseDTO>> GetMemberQResponse()
		{
			int memberId = _member_id;
			if(memberId <= 0) { 
				throw new Exception("請先登入會員");
			}
			else
			{
				return await _service.GetMemberQResponse(memberId);

			}
		}		

		// 傳送顧客提的問題(新增資料)
		[HttpPost("/CustomerQ")]
		public void PostCustomerQuestion([FromBody] CustomerQuestionDTO dto)
		{
			_service.PostCustomerQuestion(dto);
		}

		// 傳送會員提的問題(新增資料)，主要用於訂單問題
		[HttpPost("/MemberQ")]//此行與上一支api衝突，修改名稱
		public void PostMemberQuestion([FromBody] CustomerQuestionDTO dto)
		{
			int memberId = _member_id;
			if (memberId <= 0)
			{
				throw new Exception("請先登入會員");
			}
			else
			{
				dto.MemberId = memberId;
				_service.PostCustomerQuestion(dto);
			}
		}

		// 傳送滿意度好的紀錄
		[HttpPut("SatisfYes/{CommonQId}")]
		public void PutSatisfactionYes(int CommonQId)
		{
			_service.PutSatisfactionYes(CommonQId);
		}

		// 傳送滿意度差的紀錄
		[HttpPut("SatisfNo/{CommonQId}")]
		public void PutSatisfactionNo(int CommonQId)
		{
			_service.PutSatisfactionNo(CommonQId);
		}
	}
}
