using HcoinForBirth.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HcoinForBirth
{
	internal class Program
	{
		private static AppDbContext _db = new AppDbContext();
		static void Main(string[] args)
		{
			// 測試用
			// TestAddItem();

			// 發放生日H幣
			DateTime today = DateTime.Now;
			HcoinForBirth(today);

			// 計算Total H幣
			//var member = _db.Members.ToList();
			//for (int i = 0; i < member.Count; i++)
			//{
			//	TotalHcoin(member[i].Id);
			//}
		}

		/// <summary>
		/// For Test
		/// </summary>
		private static void TestAddItem()
		{
			AppDbContext _db = new AppDbContext();

			H_Source_Details detail = new H_Source_Details()
			{
				Member_Id = 5,
				Activity_Id = 2,
				Difference_H = 1111,
				Event_Time = DateTime.Now
			};

			_db.H_Source_Details.Add(detail);
			_db.SaveChanges();
		}

		/// <summary>
		/// 發送H幣給當月生日的會員，若今年已發送則不會有紀錄，每天執行一次
		/// </summary>
		/// <param name="today">今天的日期</param>
		private static void HcoinForBirth(DateTime today)
		{
			AppDbContext _db = new AppDbContext();
			int activityId = 2; // 生日活動Id
			int activity_value = _db.H_Activities
				.SingleOrDefault(a => a.H_Activity_Id.Equals(activityId))
				.H_Value; // 生日活動發放的H幣
			var memberInBirth = _db.Members
				.Where(m => m.Birthday.Month.Equals(today.Month))
				.ToList(); // 這個月份生日的會員
			var memberBirthInActivity = _db.H_Source_Details
				.Where(d => d.Activity_Id.Equals(activityId) && d.Event_Time.Year.Equals(today.Year))
				.ToList(); // 生日活動今年已發放過的紀錄

			foreach (var member in memberInBirth)
			{
				//var sendHcoin = memberBirthInActivity.Where(a => a.Member_Id == member.Id);
				try
				{
					if (!memberBirthInActivity.Any(a => a.Member_Id == member.Id))
					{
						H_Source_Details detail = new H_Source_Details()
						{
							Member_Id = member.Id,
							Activity_Id = activityId,
							Difference_H = activity_value,
							Event_Time = today
						};

						_db.H_Source_Details.Add(detail);
						_db.SaveChanges();
					}
					else
					{
						Console.WriteLine("今年已發送過了");
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

		/// <summary>
		/// 計算所有 H coin
		/// </summary>
		/// <param name="id"></param>
		public static void TotalHcoin(int id)
		{
			AppDbContext _db = new AppDbContext();

			// 找出會員所有活動的紀錄
			var detail = _db.H_Source_Details.Where(d => d.Member_Id == id);

			// 計算H幣總額
			int total = 0;
			foreach (var item in detail)
			{
				total += item.Difference_H;
			}

			// 修改Member的Total_H
			var member = _db.Members.Find(id);
			member.Total_H = total;

			_db.SaveChanges();
		}
	}
}