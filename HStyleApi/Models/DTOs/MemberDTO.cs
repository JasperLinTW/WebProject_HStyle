using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public int? PermissionId { get; set; }
        public DateTime? Jointime { get; set; }
        public bool? MailVerify { get; set; }
        public string MailCode { get; set; }
        public int? TotalH { get; set; }
        public string EncryptedPassword { get; set; }
    }
    public static class MemberExts
    {
        public static MemberDTO ToDto(this Member source)
        => new MemberDTO
        {
            Id = source.Id,
            Name = source.Name,
            Email = source.Email,
            Account = source.Account,
            PhoneNumber = source.PhoneNumber,
            Address = source.Address,
            Gender = source.Gender,
            Birthday = source.Birthday,
            PermissionId = source.PermissionId,
            Jointime = source.Jointime,
            MailVerify = source.MailVerify,
            MailCode=source.MailCode,
            TotalH=source.TotalH,
            EncryptedPassword=source.EncryptedPassword,

        };
    }
}
