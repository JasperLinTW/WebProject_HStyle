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
