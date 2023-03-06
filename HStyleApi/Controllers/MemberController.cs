using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HStyleApi.Models.InfraStructures;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.AspNetCore.Authorization;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HStyleApi.Controllers
{




    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        //private readonly MemberServices _Service;

        //public MemberController(AppDbContext db)
        //{
        //    _Service = new MemberServices(db);
        //}

        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        //    [HttpPost("LogIn")]
        //    public string LogIn(LogInDTO value)
        //    {
        //        var member = _context.Members.FirstOrDefault(x => x.Account == value.Account);

        //        if (member == null)
        //        {
        //            return ("帳密有誤");
        //        }

        //        if (member.MailVerify == false)
        //        {
        //            return ("會員資格尚未確認");
        //        }

        //        string encryptedPwd = HashUtility.ToSHA256(value.Password, RegisterDTO.SALT);

        //        if (String.CompareOrdinal(member.EncryptedPassword, encryptedPwd) != 0)
        //        {
        //            return "帳號或密碼錯誤";
        //        }
        //        else
        //        {
        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, member.Account),
        //                new Claim("FullName", member.Name),
        //	// new Claim(ClaimTypes.Role, "Administrator")
        //};
        //            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        //        };
        //        return "登入成功";
        //    }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public IActionResult LogIn(LogInDTO value)
        {
            var member = _context.Members.FirstOrDefault(x => x.Account == value.Account);

            if (member == null)
            {
                return BadRequest("帳號或密碼錯誤");
            }

            string encryptedPwd = HashUtility.ToSHA256(value.Password, RegisterDTO.SALT);

            if (String.CompareOrdinal(member.EncryptedPassword, encryptedPwd) != 0)
            {
                return BadRequest("帳號或密碼錯誤");
            }

            if (member.MailVerify == false)
            {
                return BadRequest("會員資格尚未確認");
            }
            else
            {
                var claims = new List<Claim>
                 {
                   new Claim("MemberId", member.Id.ToString()), //測試用
                   new Claim(ClaimTypes.Name, member.Account),
                   new Claim("FullName", member.Name),
                  };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }

            // 建立一個包含用戶相關聲明(Claim)的JavaScript對象
            var userData = new
            {
                id = member.Id,
                account = member.Account,
                name = member.Name,
                email = member.Email,
            };

            // 將JavaScript對象傳遞回前端
            return Ok(userData);
        }

        [HttpGet("id")]
        public int GetMemberId()
        {
            var claims = User.FindFirst("MemberId");
            if (claims != null)
            {
                int memberId = int.Parse(claims.Value);
                // Do something with the member ID
                return memberId;
            }
            else
            {
                // 無法獲取 MemberId，返回未授權狀態碼
                return (1213);
            }
        }

        [Authorize]
        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            var claims = User.FindFirst("MemberId");
            if (claims != null)
            {
                int memberId = int.Parse(claims.Value);
                // Do something with the member ID
            }
            if (User.Identity.IsAuthenticated)
                {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok("登出成功");
            }
            else
            {
                return BadRequest("您尚未登入");
            }

        }

        [HttpPost("NoLogin")]
        public void NoLogin()
        {
            
        }

        [Authorize]
        [HttpPost("Register")]
        public async Task<string> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                return "輸入錯誤";
            }
            if (_context.Members.Any(x => x.Account == register.Account))
            {
                return "帳號已存在";
            }

            Member member = new Member
            {
                //Account = register.Account,
                //Name = register.Name,
                //EncryptedPassword = register.EncryptedPassword,
                //PhoneNumber = register.Phone_Number,
                //Email = register.Email,
                //Birthday = register.Birthday,
                //Gender=register.Gender,
                //Address = register.Address,
                //IsConfirmed = false,
                //ConfirmCode = Guid.NewGuid().ToString("N"),

                Name = register.Name,                         //試抓出   MemberRepository
                Email = register.Email,
                Account = register.Account,
                PhoneNumber = register.Phone_Number, //手機號碼
                Address = register.Address,
                Gender = register.Gender,
                Birthday = register.Birthday,
                PermissionId = 1,
                Jointime = DateTime.Now,
                MailVerify = false, //預設是未確認的會員  IsConfirmed=我資料庫的 Mail_verify
                MailCode = Guid.NewGuid().ToString("N"),//mail的確認確認碼  ConfirmCode=我資料庫的 Mail_code
                EncryptedPassword = register.EncryptedPassword, //加密密碼 
                TotalH = 0,

            };
            _context.Members.Add(member);
            _context.SaveChanges();
            SendEmail(member);  //確認寄信用  
            return "註冊成功";
        }

        [HttpPost("SendEmail")]
        public string SendEmail(Member member)
        {

            var message = new MimeMessage();

            // 添加寄件者
            message.From.Add(new MailboxAddress("PawPaw", "pawpawpetSite@gmail.com"));

            // 添加收件者
            message.To.Add(new MailboxAddress("New Member", $"{member.Email}"));

            // 設定郵件標題
            message.Subject = "Welcome";

            // 使用 BodyBuilder 建立郵件內容
            var bodyBuilder = new BodyBuilder();

            string result = Request.Scheme + "://" + Request.Host + $"/api/Member/EmailConfirm/?account={member.Account}&confirmCode={member.MailCode}";

            // 設定 HTML 內容
            bodyBuilder.HtmlBody = $"<a href=\"{result}\">點此連結驗證</a>";

            // 設定郵件內容
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("vunvun0213@gmail.com", "yvupanwipdifkupw");
                client.Send(message);
                client.Disconnect(true);
            }
            return "成功";
        }
        [HttpGet("EmailConfirm")]
        public string EmailConfirm(string account, string confirmCode)
        {

            var emailmember = _context.Members.FirstOrDefault(x => x.Account == account);
            if (emailmember == null)
            {
                return "認證失敗";
            }
            else if (string.Compare(confirmCode, emailmember.MailCode) != 0) { return "認證失敗"; }
            else
            {
                emailmember.MailVerify = true;

                emailmember.MailCode = null;
                _context.SaveChanges();
                return "驗證成功";
            }
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MemberController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        }
    }

