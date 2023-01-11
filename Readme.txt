-- add Db, H_Activities_Category H_Source_Details H_CheckIns table, EFModels, H_ActivityVm
[V] add H2StyleStore mvc project
[V]Create HstyleStore db(ispan, ***), H_Activities_Category table
	H_A_Category_Id, int, PK, not null, identity
	Activity_Name, NVarchar(50), not null
	Activity_Describe, NVarchar(max), not null
	H_Value, int, not null
   Create H_Source_Details table
    Source_H_Id, int, PK, not null, identity
	Member_Id, int 
	Activity_Id, int
	Difference_H, int
	Event_Time, datetime
   Create H_CheckIns table
    CheckIn_H_Id, int
	Member_Id, Int
	Activity_Id, int
	CheckIn_Times, int
	Last_Time, datetime
[V]add EFModels, AppDbContext, connection string='AppDbConn'
[V]add ViewModels/H_Activities_CategoryVM, DTOs/H_Activities_CategoryDto class
	add 擴充方法 H_Activities_CategoryDto ToDto(this H_Activities_CategoryVM source)
[V]add H_Activities_CategoryController, HcoinActivity action

-- 實作 H_ActivityService, IH_ActivityRepository, H_ActivityRepository
	display H_Activity

-- add H_Source_DetailsController, H_Source_DetailVM, H_Source_DetailService,H_Source_DetailDto
       IH_Source_DetailRepository, H_Source_DetailRepository
	   並建立與H_Activity的關聯

-- 建立與Member的關聯
   並 add EFModel/Member, Create H_Activity, Edit  H_Activity   
[V] H_Activities/Create.html, H_Activities/Create.html
[V] Index.cshtml add button to CreateActivity.cshtml
[V] add CheckIn to display from HDetail.cshtml
[V] modify ActivityController/CreateActivity{return "View"=>"RedirectToAction"}

-- add ActivityController/DeleteActivity, H_Source_DetailsController/DeleteDetail

-- 實作註冊活動功能
[V?] add H_ActivityService/HcoinRegister
[V?] add H_Source_DetailService/CreateDetail, 
                 IH_Source_DetailRepository/CreateHDetail,
				 H_Source_DetailService/CreateHDetail

-- 實作購物滿額送H幣
[V?] add H_ActivityService/HcoinOrderPrice
[V?] use H_Source_DetailService/CreateDetail, 
                 IH_Source_DetailRepository/CreateHDetail,
				 H_Source_DetailService/CreateHDetail

-- 更改版面
   [V] modify _Layout
   [V] add css file and js file

-/- add H_Source_Detail Searchs
   [X] SelectListItem  

-/- 實作生日送H幣活動

-/- 計算ToTal Hcoin，傳入Member Table 的 H_value欄位