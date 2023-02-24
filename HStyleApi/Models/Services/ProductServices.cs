using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using HStyleApi.Models.InfraStructures.Repositories;
using System.Collections.Generic;

namespace HStyleApi.Models.Services
{
	public class ProductServices
	{
		private readonly ProductRepo _repo;
		public ProductServices(AppDbContext db)
		{
			_repo = new ProductRepo(db);
		}

		public IEnumerable<ProductDto> LoadProducts()
		{
			var data = _repo.LoadProducts();
			return data;
		}

		public ProductDto GetProduct(int product_id)
		{
			var data = _repo.GetProduct(product_id);

			return data;

		}

		//public IEnumerable<ProductDto> GetRecommend(int product_id, int member_id)
		//{

		//	//若無登入或無購買紀錄就以目前瀏覽的商品有相同tag作為推薦

		//	//取得member有買過的商品資料
		//	var data = _repo.GetOrderProducts(member_id);

		//	//以member購買過的商品具相同tag作為推薦

		//	return null;

		//}



		public (bool, string) CreateComment(PCommentPostDTO dto, int orderId, int productId)
		{
			//TODO驗證

			_repo.CreateComment(dto, orderId, productId);

			return (true, "新增成功");
		}

		public PCommentGetDTO GetComment(int productId, int orderId)
		{
			var data = _repo.GetComment(productId, orderId);

			return data;
		}

		public void HelpfulComment(int comment_id, int member_id)
		{
			_repo.HelpfulComment(comment_id, member_id);
		}

		public IEnumerable<PCommentDTO> LoadComments()
		{
			var data = _repo.LoadComments();
			return data;
		}

		public void LikesProduct(int product_id, int member_id)
		{
			_repo.LikesProduct(product_id, member_id);
		}

		public IEnumerable<Product_LikeDTO> LoadLikeProducts(int member_id)
		{
			var data = _repo.LoadLikeProducts(member_id);

			return data;
		}

		public IEnumerable<ProductDto> GetRecommendByProducts(int product_id)
		{
			//取得此筆product的所有tag Id
			var data = _repo.GetProductInfo(product_id);

			var tags = data.Tags.Select(x => x.Id);
			//找出其他有這個tag的商品

			var products_id = _repo.GetProductByTags(tags, product_id);


			//如果有這個tag的商品大於三件亂數去取隨機商品
			int targetnumber = 3;
			IEnumerable<ProductDto> products;
			IEnumerable<ProductDto> otherproducts;
			List<int> recommendlist = new List<int>();
			List<int> list_id = new List<int>();
			if (products_id.Count > targetnumber)
			{
				recommendlist = RandomSelect(products_id, targetnumber);
				products = _repo.GetProducts(recommendlist);
				return products;
			}
			//如果有這個tag的商品小於三件則用顏色去補
			else if (products_id.Count < targetnumber)
			{
				list_id.Add(product_id);
				foreach (var id in products_id)
				{
					list_id.Add(id);
				}
				products = _repo.GetProducts(products_id);

				//取出此筆訂單的color
				var colors = data.Specs.Select(x => x.Color);

				//取出沒有此tag但有這個color的商品
				var otherproducts_id = _repo.GetProductByColor(colors, list_id);

				//如果有此color的product > 3
				if (otherproducts_id.Count > 3)
				{
					recommendlist = RandomSelect(otherproducts_id, targetnumber - products_id.Count);
					otherproducts = _repo.GetProducts(recommendlist);
					return products.Union(otherproducts);
				}

				otherproducts = _repo.GetProducts(otherproducts_id).Distinct();  
				return products.Union(otherproducts); 			
			}
			//剛好三件
			products = _repo.GetProducts(products_id);

			return products;
		}

		public List<int> RandomSelect(List<int> products_id, int targetnumber)
		{
			//1.產生一原始陣列
			int[] original = new int[products_id.Count];
			for (int i = 0; i < original.Length; i++)
			{
				original[i] = i;
			}

			int startnumber = original[0];
			int totalnumber = products_id.Count - 1;

			//2.洗牌
			for (int i = 0; i < original.Length; i++)
			{
				int seed = Guid.NewGuid().GetHashCode();
				var random = new Random(seed);
				int position = random.Next(startnumber, totalnumber); //和哪個位子換數字
				int temp;
				temp = original[i];
				original[i] = original[position];
				original[position] = temp;
			}
			//3.輸出結果 隨機取出product id
			int[] hash = new int[targetnumber];
			Array.Copy(original, hash, targetnumber);

			List<int> recommendlist = new List<int>();
			foreach (var item in hash)
			{
				recommendlist.Add(products_id[item]);
			}

			return recommendlist;
		}
	}
}
