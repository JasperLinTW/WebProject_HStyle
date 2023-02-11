﻿using HcoinForBirth.EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ScheduleWork
{
	internal class Program
	{
		private static AppDbContext _db = new AppDbContext();
		static void Main(string[] args)
		{
			DateTime today = DateTime.Now;
			// 發放生日H幣
			HcoinForBirth(today);
			// 發放購物活動H幣
			HcoinForOrder(today);
		}

		/// <summary>
		/// 發送H幣給當月生日的會員，若今年已發送則不會有紀錄，每天執行一次
		/// </summary>
		/// <param name="today">今天的日期</param>
		private static void HcoinForBirth(DateTime today)
		{
			//AppDbContext _db = new AppDbContext();
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
						// 加入Member中的Total_H
						Member memberData = _db.Members.SingleOrDefault(m => m.Id == member.Id);
						memberData.Total_H += activity_value;
						_db.SaveChanges();

						// 新增一筆紀錄
						H_Source_Details detail = new H_Source_Details()
						{
							Member_Id = member.Id,
							Activity_Id = activityId,
							Difference_H = activity_value,
							Event_Time = today,
							Total_H_SoFar = memberData.Total_H
						};
						_db.H_Source_Details.Add(detail);
						_db.SaveChanges();

						Console.WriteLine(member.Account.ToString() + "獲得生日活動H幣");
					}
					//else
					//{
					//	Console.WriteLine("今年已發送過了");
					//}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

		/// <summary>
		/// 購物滿額，就送H幣，訂單結案且已送貨後30天發放，若有人退訂就手動新增刪除H幣的紀錄
		/// </summary>
		/// <param name="today">今天的時間</param>
		private static void HcoinForOrder(DateTime today)
		{
			//AppDbContext _db = new AppDbContext();
			// 購物額滿的金額
			int fullPriceId = 4;
			int fullPrice = _db.H_Activities.SingleOrDefault(a => a.H_Activity_Id == fullPriceId).H_Value;
			// 購物滿額發送的H幣
			int hCoinId = 5;
			int hCoin = _db.H_Activities.SingleOrDefault(a => a.H_Activity_Id == hCoinId).H_Value;
			// 已發送過H幣的訂單(三個月內)
			DateTime inDays = today.AddDays(-90);
			var orderInSources = _db.H_Source_Details
				.Where(d => d.Event_Time > inDays && d.Activity_Id.Equals(hCoinId))
				.ToList();
			// 取得符合條件(發貨時間一個月後，訂單狀態為已完成)的訂單資訊
			int orderState = 5; // 訂單狀態為"已完成"的Id
			DateTime beforeDays = Convert.ToDateTime(today.AddDays(-30).ToString("yyyy-MM-dd")); // 送貨時間為30天前
			var orders = _db.Orders
				.Where(o => DbFunctions.TruncateTime(o.ShippedDate).Value.CompareTo(beforeDays) < 1
				&& DbFunctions.TruncateTime(o.ShippedDate).Value.CompareTo(beforeDays) > -1
				&& o.Status_id.Equals(orderState))
				.ToList();

			foreach (var order in orders)
			{
				try
				{
					if (!orderInSources.Any(s => s.Remark.Contains("訂單編號:" + order.Order_id.ToString())))
					{
						// 加入Member中的Total_H
						Member memberData = _db.Members.SingleOrDefault(m => m.Id == order.Member_id);
						memberData.Total_H += hCoin;
						_db.SaveChanges();

						// 新增一筆紀錄
						H_Source_Details detail = new H_Source_Details()
						{
							Member_Id = order.Member_id,
							Activity_Id = hCoinId,
							Difference_H = hCoin,
							Event_Time = today,
							Total_H_SoFar = memberData.Total_H,
							Remark = "訂單編號:" + order.Order_id.ToString()
						};
						_db.H_Source_Details.Add(detail);
						_db.SaveChanges();

						Console.WriteLine($"訂單:{order.Order_id.ToString()}，已發送貨幣");
					}
					//else
					//{
					//	Console.WriteLine("今年已發送過了");
					//}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

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

			total = detail.Sum(d => d.Difference_H);
			//foreach (var item in detail)
			//{
			//	total += item.Difference_H;
			//}

			// 修改Member的Total_H
			var member = _db.Members.Find(id);
			member.Total_H = total;

			_db.SaveChanges();
		}
	}
}