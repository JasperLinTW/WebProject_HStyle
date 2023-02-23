using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System.Net;

namespace HStyleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaypalController : ControllerBase
	{
		private readonly IConfiguration _config;

		public PaypalController(IConfiguration config)
		{
			_config = config;
		}
		

		[HttpPost]
		public async Task<IActionResult> CreateOrder()
		{
			//client是指我們申請的商城帳號，由appsetting設定，注入_config，包含ClientId和Secret
			var client = new PayPalHttpClient(new SandboxEnvironment(
				_config["PayPal:ClientId"],
				_config["PayPal:ClientSecret"]
			));

			var request = new OrdersCreateRequest();
			request.Prefer("return=representation");//這句表示請求發給paypal時，要返回詳細資訊而不是只有付款url
			request.RequestBody(BuildRequestBody());

			var response = await client.Execute(request);

			if (response.StatusCode != System.Net.HttpStatusCode.Created)
			{
				return BadRequest();
			}

			var result = response.Result<Order>();

			return Ok(new
			{
				orderId = result.Id,
				links = result.Links
					.Where(x => x.Rel == "approve")
					.Select(x => new
					{
						href = x.Href,
						method = x.Method
					})
			
			});
		}

		private OrderRequest BuildRequestBody()
		{
			var order = new OrderRequest()
			{
				CheckoutPaymentIntent = "CAPTURE",//表示消費者按下付款後會立即處理，AUTHORIZE則是僅授權，之後再手動處理
				ApplicationContext = new ApplicationContext
				{
					ReturnUrl = "https://www.google.com.tw/?hl=zh_TW",
					CancelUrl = "https://www.google.com.tw/?hl=zh_TW",
					Locale= "zh-TW",
				},
				PurchaseUnits = new List<PurchaseUnitRequest>
				{
					new PurchaseUnitRequest
					{
						ReferenceId = "PUHF",//識別用，可以亂取
						Description = "HStyle商城付款頁面",//顯示給消費者看得描述
						AmountWithBreakdown = new AmountWithBreakdown
						{
							CurrencyCode = "TWD",
							Value = "92.00"
						}
					
					}
				}
			
			};
			return order;
		}

		[HttpGet("return")]
		public async Task<IActionResult> Return([FromQuery] string token, [FromQuery] string PayerID)
		{
			var client = new PayPalHttpClient(new SandboxEnvironment(
				_config["PayPal:ClientId"],
				_config["PayPal:ClientSecret"]
			));

			var request = new OrdersCaptureRequest(token);
			request.RequestBody(new OrderActionRequest());

			var response = await client.Execute(request);

			if (response.StatusCode != System.Net.HttpStatusCode.Created)
			{
				return BadRequest();
			}

			return Ok("Payment successful.");
		}

		[HttpGet("cancel")]
		public IActionResult Cancel()
		{
			return Ok("Payment cancelled.");
		}

		[HttpPost("{orderId}")]
		public async Task<IActionResult> ConfirmOrder(string orderId)
		{
			var client = new PayPalHttpClient(new SandboxEnvironment(
				_config["PayPal:ClientId"],
				_config["PayPal:ClientSecret"]
			));
			var request = new OrdersCaptureRequest(orderId);
			request.RequestBody(new OrderActionRequest());
			var response = await client.Execute(request);

			if (response.StatusCode == HttpStatusCode.Created)
			{
				// 付款成功，更新訂單狀態
				
				return Ok("付款成功");
			}
			else
			{
				// 付款失敗
				return BadRequest();
			}
		}

	}
}
