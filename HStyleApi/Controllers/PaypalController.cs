using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

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
			var client = new PayPalHttpClient(new SandboxEnvironment(
				_config["PayPal:ClientId"],
				_config["PayPal:ClientSecret"]
			));

			var request = new OrdersCreateRequest();
			request.Prefer("return=representation");
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
				CheckoutPaymentIntent = "CAPTURE",
				ApplicationContext = new ApplicationContext
				{
					ReturnUrl = "http://localhost:5000/paypal/return",
					CancelUrl = "http://localhost:5000/paypal/cancel"
				},
				PurchaseUnits = new List<PurchaseUnitRequest>
				{
					new PurchaseUnitRequest
					{
						ReferenceId = "PUHF",
						Description = "Test Transaction",
						AmountWithBreakdown = new AmountWithBreakdown
						{
							CurrencyCode = "USD",
							Value = "100.00"
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
	}
}
