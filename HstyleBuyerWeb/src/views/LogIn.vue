<template>
   <div v-show="!isLoging" class="container mt-5 mb-6 py-2 login px-10">
      <div class="row">
         <div class="col-md-12 mt-5 mb-4 fz-big">會員登入</div>
         <div class="col-md-6 pb-2 border-bottom">
            <button class="btn-underline" @click="showLogin = false" :class="{ active: !showLogin }">新會員註冊</button>
         </div>
         <div class="col-md-6 border-bottom">
            <button class="btn-underline" @click="showLogin = true" :class="{ active: showLogin }">會員登入</button>
         </div>
         <div v-if="showLogin" class="m-0 p-0 h-500px">
            <div class="mt-3">
               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="account" required />
                  <label for="floatingInput">帳號</label>
               </div>
               <div class="form-floating">
                  <input type="password" class="form-control" id="floatingPassword" v-model="password" require />
                  <label for="floatingPassword">密碼</label>
               </div>
            </div>
            <div class="col-md-12 mt-3">
               <div class="row">
                  <div class="col-md-12 d-flex justify-content-center">
                     <button type="button" @click="login" class="btn_Login mt-3 px-5 ms-6">登入</button>
                     <button
                        type="button"
                        class="btn btn-link mt-3 ps-5"
                        data-bs-toggle="modal"
                        data-bs-target="#exampleModal456"
                        data-bs-whatever="@mdo"
                     >
                        忘記密碼?
                     </button>
                  </div>
               </div>
            </div>
            <div class="text-start mt-5">
               <button class="btn btn-link text-dark text-decoration-none" @click="fillIn">填入正式用</button>
               <button class="btn btn-link text-dark text-decoration-none" @click="fillIn1">填入註冊驗證</button>
            </div>
         </div>
         <div v-else class="m-0 p-0">
            <div class="col-md-12 mt-3 h-500px">
               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="Rname" required />
                  <label for="floatingInput">姓名</label>
               </div>
               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="Raccount" required />
                  <label for="floatingInput">帳號</label>
                  <div v-if="error.Raccount" class="text-danger">{{ error.Raccount }}</div>
               </div>
               <div class="form-floating mb-3">
                  <input type="password" class="form-control" id="floatingInput" v-model="Rpassword" required />
                  <label for="floatingInput">密碼</label>
                  <div v-if="error.Rpassword" class="text-danger">{{ error.Rpassword }}</div>
               </div>
               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="Remail" required />
                  <label for="floatingInput">信箱</label>
                  <div v-if="error.Remail" class="text-danger">{{ error.Remail }}</div>
               </div>
               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="Raddress" required />
                  <label for="floatingInput">地址</label>
                  <div v-if="error.Raddress" class="text-danger">{{ error.Raddress }}</div>
               </div>
               <div class="form-floating mb-3">
                  <input type="date" class="form-control" id="floatingInput" v-model="Rbirthday" required />
                  <label for="floatingInput">生日</label>
                  <div v-if="error.Rbirthday" class="text-danger">{{ error.Rbirthday }}</div>
               </div>
               <div class="col-md-12">
                  <div class="row d-flex justify-content-start mb-2">
                     <div class="col-md-4 text-start p-0 fz-10"><label class="ps-c">性別</label></div>
                     <div class="col-md-4 text-start">
                        <input class="form-check-input" type="radio" name="gender" id="male" value="true" v-model="Rgender" />
                        <label class="form-check-label" for="male"> 男 </label>
                     </div>
                     <div class="col-md-4 text-start">
                        <input class="form-check-input" type="radio" name="gender" id="female" value="false" v-model="Rgender" />
                        <label class="form-check-label" for="female"> 女 </label>
                     </div>
                  </div>
               </div>

               <div class="form-floating mb-3">
                  <input type="text" class="form-control" id="floatingInput" v-model="Rphone_Number" required />
                  <label for="floatingInput ms-2">電話</label>
               </div>

               <div class="row mb-5">
                  <div class="col-md-3"></div>
                  <div class="col-md-5">
                     <button type="button" @click="Register" class="btn_Login mt-3 ms-5 px-6">註冊</button>
                     <div>
                        <button class="btn btn-link text-dark text-decoration-none mt-3 ms-5 px-7" @click="RfillIn">填入註冊資訊</button>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <!-- <div class="col-md-3">
              <div class="pt-4 mt-1 text-start fz-sm">忘記密碼?</div>
            </div> -->

         <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@fat">Open modal for @fat</button>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Open modal for @getbootstrap</button> -->

         <div class="modal fade" id="exampleModal456" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
               <div class="modal-content">
                  <div class="modal-header">
                     <h1 class="modal-title fs-5" id="exampleModalLabel">請輸入帳號信箱以更新密碼</h1>
                     <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                     <form>
                        <div class="mb-3 form-floating">
                           <input type="text" class="form-control" id="forgetaccont" v-model="forgetaccont" require />
                           <label for="forgetaccont" class="col-form-label">帳號</label>
                        </div>
                        <div class="mb-3 form-floating">
                           <input class="form-control" id="mail" v-model="mail" require />
                           <label for="mail" class="col-form-label">信箱</label>
                        </div>
                     </form>
                  </div>
                  <div class="modal-footer border-0">
                     <button type="button" class="btn btn-link text-dark text-decoration-none" @click="fillIn2">填入註冊驗證</button>
                     <button type="button" class="btn_Login" @click="ForgetPassword">送出驗證信</button>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <!-- <button type="button" @click="getMemberId" class="btn btn-light">取id</button>
        <button type="button" @click="getCartInfo" class="btn btn-light">取購物車測試</button> -->
   </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";
import { eventBus } from "../mybus";

const router = useRouter();
const account = ref("");
const password = ref("");
const forgetaccont = ref("");
const mail = ref("");
const isLoging = ref(true);

const Raccount = ref("");
const Rpassword = ref("");
const Raddress = ref("");
const Rbirthday = ref(new Date());
const Rname = ref("");
const Remail = ref("");
const Rphone_Number = ref("");
const Rgender = ref("male");

const phoneRegex = /^09\d{8}$/;
const nameRegex = /^[\u4e00-\u9fa5]{2,5}$/;
const accountPattern = /^[a-zA-Z][a-zA-Z0-9_]{5,15}$/;
const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
const addersPattern = /^[\u4e00-\u9fa5]{3,}(?:縣|市|區|鄉|鎮|村|里)?[\u4e00-\u9fa5]{2,}(?:街|路|巷)?\d{1,4}[號樓室]?$/;

const login = () => {
   axios
      .post(
         "https://localhost:7243/api/Member/LogIn",
         {
            account: account.value,
            password: password.value,
         },
         { withCredentials: true }
      )
      .then((response) => {
         console.log(response.data);
         eventBus.emit("Login");
         router.go(-1);
      })
      .catch((error) => {
         if (error.response.status === 400) {
            //傳回BadRequest
            alert(error.response.data);
         }
      });
};

const checkLogin = () => {
   axios
      .get("https://localhost:7243/api/Member/id", { withCredentials: true })
      .then((response) => {
         if (response.data <= 0) {
            isLoging.value = false;
         } else {
            router.push("/");
         }
      })
      .catch((error) => {
         console.error(error);
      });
};

const ForgetPassword = () => {
   axios
      .post(
         "https://localhost:7243/api/Member/ForgetPassword",
         {
            account: forgetaccont.value,
            email: mail.value,
         },
         { withCredentials: true }
      )
      .then((response) => {
         alert(response.data);
         window.location = "http://localhost:5173/account/MemberAddresses";
      })
      .catch((err) => {
         console.log(err);
      });
};

const Register = () => {
   if (!validateForm()) {
      return;
   }
   axios
      .post(
         "https://localhost:7243/api/Member/Register",
         {
            account: Raccount.value,
            password: Rpassword.value,
            address: Raddress.value,
            birthday: Rbirthday.value,
            gender: Rgender.value,
            name: Rname.value,
            phone_Number: Rphone_Number.value,
            email: Remail.value,
         },
         { withCredentials: true }
      )
      .then((response) => {
         alert(response.data);
         window.location = "http://localhost:5173/account/MemberAddresses";
      })
      .catch((err) => {
         console.log(err);
      });
};

const showLogin = ref(true);

onMounted(() => {
   checkLogin();
});

const error = ref({});
const validateForm = () => {
   error.value = {};

   if (!Rname.value) {
      error.value.name = "收件姓名必填";
   } else if (Rname.value.length < 2) {
      error.value.name = "姓名長度太短";
   }
   if (!Rname.value) {
      error.value.Raccount = "帳號必填";
   }

   if (!Rname.value) {
      error.value.Rpassword = "密碼必填";
   }
   const emailRegex = /^[^\s@]+@[^\s@]+.[^\s@]+$/;
   if (!Rname.value) {
      error.value.Remail = "信箱必填";
   } else if (!emailRegex.test(Remail.value)) {
      error.value.Remail = "信箱格式錯誤,例xxx@gmcil.com";
   }
   const addressPattern = /^(台灣省|台灣|臺灣省|臺灣)?([^\s]+?[市|縣|州])([^\s]+?[區|鄉|鎮])([^\s]+?(?:街|路|巷))([^\s]+?(?:號))?$/;
   if (!Raddress.value) {
      error.value.Raddress = "地址欄位必填";
   } else if (!addressPattern.test(Raddress.value)) {
      error.value.Raddress = "地址格式錯誤,例:桃園市中壢區新生路二段421號";
   }
   if (!Rbirthday.value) {
      error.value.Rbirthday = "生日欄位必填";
   }
   if (!Rgender.value) {
      error.value.Rgender = "性別欄位必填";
   }
   const phonePattern = /^09\d{8}$/;
   if (!Rphone_Number.value) {
      error.value.Rphone_Number = "電話欄位必填";
   } else if (!phonePattern.test(Rphone_Number.value)) {
      error.value.Rphone_Number = "電話格式錯誤,例:0900000000";
   }
   // 所有驗證都通過，返回 true
   return true;
};

//以下是登入填值用
const fillIn = () => {
   account.value = "Angela0301";
   password.value = "test";

   return {
      account,
      password,
      fillIn,
   };
};
const fillIn1 = () => {
   account.value = "test88888";
   password.value = "test88888";

   return {
      account,
      password,
      fillIn1,
   };
};
const fillIn2 = () => {
   forgetaccont.value = "test88888";
   mail.value = "vunvun1120@gmail.com";

   return {
      forgetaccont,
      mail,
      fillIn2,
   };
};
//以下註冊用

const RfillIn = () => {
   Raccount.value = "test88888";
   Rpassword.value = "test88888";
   Raddress.value = "桃園市中壢區新生路二段421號";
   Rbirthday.value = Date.now;
   Rgender.value = true;
   Rname.value = "test88888";
   Rphone_Number.value = "0955878888";
   Remail.value = "vunvun1120@gmail.com";
   return {
      Raccount,
      Rpassword,
      Raddress,
      Rbirthday,
      Rgender,
      Rname,
      Rphone_Number,
      Remail,
      RfillIn,
   };
};
</script>

<style scoped>
.fz-10 {
   font-size: 13.5px;
   padding-left: 5%;
   color: #6c757d;
}

.ps-c {
   padding-left: 5%;
}

.btn-link {
   text-decoration: none;
   color: #000;
}

.btn-link:hover {
   color: #adb5bd;
}

.ms-6 {
   margin-left: 21%;
   padding-left: 10%;
   padding-right: 10%;
}

.fz-sm {
   font-size: 14px;
}

.px-10 {
   padding-left: 19%;
   padding-right: 19%;
}

.fz-big {
   font-size: 20px;
   font-weight: bold;
}

.login {
   height: 100%;
}

.mb-6 {
   margin-bottom: 50px;
}

.h-500px {
   height: 720px;
}

.textbox {
   border: none;
   border-bottom: 1px solid transparent;
   outline: none;
   font-size: 16px;
   transition: border-bottom-color 0.2s ease-in-out;
   padding-right: 4px;
}

.btn_Login {
   background-color: #fff;
   color: rgb(12, 13, 12);
   padding: 10px 28px;
   border-radius: 25px;
   border: 1px solid rgb(12, 13, 12);
   transition: all 0.3s ease;
}

.btn_Login1 {
   background-color: #fff;
   color: rgb(12, 13, 12);
   padding: 10px 28px;
   margin: 50px;
   border-radius: 25px;
   border: 1px solid rgb(12, 13, 12);
   transition: all 0.3s ease;
}

.btn_Login:hover {
   background-color: #000;
   color: #fff;
}

.h-100 {
   height: auto;
}

.form-control {
   border: none;
   border-bottom: 1px solid #ccc;
   border-radius: 0;
   box-shadow: none;
}

.form-control:focus {
   border: none;
   outline: none;
   border-bottom: 1px solid #ccc;
   box-shadow: none;
}

input:-webkit-autofill,
textarea:-webkit-autofill,
select:-webkit-autofill {
   -webkit-box-shadow: 0 0 0px 1000px transparent inset !important;

   background-color: transparent;

   background-image: none;

   transition: background-color 50000s ease-in-out 0s;
}

.px-6 {
   padding-inline: 75px;
}

.btn-underline::after {
   content: "";
   position: absolute;
   bottom: 0;
   left: 0;
   width: 100%;
   height: 2px;
   background-color: #000000;
   transform: scaleX(0);
   transition: transform 0.3s ease;
}

.btn-underline:hover::after {
   transform: scaleX(1);
}

.btn-underline {
   position: relative;
   padding: 0;
   border: none;
   background: none;
   text-decoration: none;
   font-size: 12pt;
   color: #333;
   cursor: pointer;
}

.btn-underline:hover {
   color: #000000;
}
</style>
