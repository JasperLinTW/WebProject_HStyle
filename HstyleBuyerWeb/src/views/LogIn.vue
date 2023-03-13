<template>
  <div v-show="!isLoging" class="container mt-5 mb-6 py-2 login px-10">
    <div class="row">
      <div class="col-md-12 mt-5 mb-4 fz-big">會員登入</div>
      <div class="col-md-6 pb-2 border-bottom">
        <button class="btn-underline" @click="showLogin = false" :class="{ active: !showLogin }">
          新會員註冊
        </button>
      </div>
      <div class="col-md-6 border-bottom">
        <button class="btn-underline" @click="showLogin = true" :class="{ active: showLogin }">
          會員登入
        </button>
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
            <div class="col-md-3"></div>
            <div class="col-md-5">
              <button type="button" @click="login" class="btn mt-3 me-4">
                登入
              </button>
              <button type="button" class="btn btn-primary mt-3" data-bs-toggle="modal" data-bs-target="#exampleModal456" data-bs-whatever="@mdo">
                忘記密碼?
              </button>
            </div>
              </div>
      </div>
    </div>
    <div v-else class="m-0 p-0">
      <div class="col-md-12 mt-3  h-100">
        <div class="form-floating mb-3">
            <input id="name" type="text" class="form-control"  v-model="Rname" pattern="^[\u4e00-\u9fa5]{2,5}$" placeholder="請輸入姓名" required />
            <!-- <div v-if="error.name" class="text-danger ">{{ error.name }}</div> -->
            <label for="name">姓名</label>
          </div>
        <div class="form-floating mb-3">
            <input type="text" class="form-control" id="floatingInput" v-model="Raccount" required />
            <label for="floatingInput">帳號</label>
          </div>
          <div class="form-floating mb-3">
            <input type="password" class="form-control" id="floatingInput" v-model="Rpassword" required />
            <label for="floatingInput">密碼</label>
          </div>
          <div class="form-floating mb-3">
            <input type="text" class="form-control" id="floatingInput" v-model="Remail" required />
            <label for="floatingInput">信箱</label>
          </div>
          <div class="form-floating mb-3">
            <input type="text" class="form-control" id="floatingInput" v-model="Raddress" required />
            <label for="floatingInput">地址</label>
          </div>
          <div class="form-floating mb-3">
            <input type="date" class="form-control" id="floatingInput" v-model="Rbirthday" required />
            <label for="floatingInput">生日</label>
          </div>
          <div class="text-center " >
  <input class="form-check-input " type="radio" name="gender" id="male" value="true" v-model="Rgender">
  <label class="form-check-label" for="male">
    男
  </label>
</div>
<div class="text-center">
  <input class="form-check-input" type="radio" name="gender" id="female" value="false" v-model="Rgender">
  <label class="form-check-label" for="female">
    女
  </label>
</div>
          <div class="form-floating mb-3">
            <input type="text" class="form-control" id="floatingInput" v-model="Rphone_Number" required />
            <label for="floatingInput">電話</label>
          </div>
      
        <div class="row">
          <div class="col-md-3"></div>
          <div class="col-md-5">
            <button type="button" @click="Register" class="btn mt-3 me-4">
              註                            冊
            </button>
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
        <h1 class="modal-title fs-5" id="exampleModalLabel">請輸入帳號信箱以更新密碼!!</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <form>
          <div class="mb-3">
            <label for="forgetaccont" class="col-form-label">帳號:</label>
            <input type="text" class="form-control" id="forgetaccont" v-model="forgetaccont" require>
          </div>
          <div class="mb-3">
            <label for="mail" class="col-form-label">信箱:</label>
            <input class="form-control" id="mail" v-model="mail" require>
          </div>
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button>
        <button type="button" class="btn btn-primary" @click="ForgetPassword">送出驗證信</button>
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


const router = useRouter();
const account = ref("");
const password = ref("");
const forgetaccont = ref("");
const mail = ref("");
const isLoging = ref(true)

const Raccount = ref("")
const Rpassword = ref("")
const Raddress = ref("")
const Rbirthday = ref(new Date())
const Rname = ref("")
const Remail = ref("")
const Rphone_Number = ref("")
const Rgender = ref('male')

const emailRegex = /^[^\s@]+@[^\s@]+.[^\s@]+$/;
const phoneRegex = /^09\d{8}$/;
const nameRegex=/^[\u4e00-\u9fa5]{2,5}$/;
const accountPattern=/^[a-zA-Z][a-zA-Z0-9_]{5,15}$/;
const passwordPattern=/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
const addersPattern=/^[\u4e00-\u9fa5]{3,}(?:縣|市|區|鄉|鎮|村|里)?[\u4e00-\u9fa5]{2,}(?:街|路|巷)?\d{1,4}[號樓室]?$/;


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
      router.go(-1);
    })
    .catch((error) => {
      if (error.response.status === 400) {  //傳回BadRequest
      alert(error.response.data);}
    });
};

const checkLogin = () => {
  axios
    .get("https://localhost:7243/api/Member/id", { withCredentials: true })
    .then((response) => {
      if (response.data <= 0) {
        isLoging.value = false;
      }
      else {
        router.push("/");
      }
    })
    .catch((error) => {
      console.error(error);
    });
};

  const ForgetPassword = () => {
  axios.post('https://localhost:7243/api/Member/ForgetPassword', {
    account: forgetaccont.value,
    email: mail.value,

  }, { withCredentials: true }).then((response) => {
    alert(response.data)
    window.location = "http://localhost:5173/account/MemberAddresses";

  }).catch((err) => {
    console.log(err)
  })
};

const Register = () => {
  // if (!validateForm()) {
  //   return;
  // };
  axios.post('https://localhost:7243/api/Member/Register', {
    account: Raccount.value,
    password:Rpassword.value,
    address:Raddress.value,
    birthday:Rbirthday.value,
    gender:Rgender.value,
    name:Rname.value,
    phone_Number:Rphone_Number.value,
    email: Remail.value,

  }, { withCredentials: true }).then((response) => {
    alert(response.data)
    window.location = "http://localhost:5173/account/MemberAddresses";

  }).catch((err) => {
    console.log(err)
  })
};
// const getCartInfo = async () => {
//   await axios
//     .get("https://localhost:7243/api/Cart", { withCredentials: true })
//     .then((response) => {
//       console.log(response.data);
//     })
//     .catch((error) => {
//       console.log(error.response.status);
//       if (error.response.status === 401) {
//         window.location = "http://localhost:5173/login";
//       }
//     });
// };
const showLogin = ref(true);

onMounted(() => {
  checkLogin();
})

const error = ref({});
const validateForm = () => {
  error.value = {};

  if (!shipName.value) {
    error.value.name = "收件姓名必填";
  }
  // 所有驗證都通過，返回 true
  return true;
}
</script>
  
<style scoped>
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

.h-500px{
  height: 500px;
}


.textbox {
  border: none;
  border-bottom: 1px solid transparent;
  outline: none;
  font-size: 16px;
  transition: border-bottom-color 0.2s ease-in-out;
  padding-right: 4px;
}

.btn {
  background-color: #fff;
  color: rgb(12, 13, 12);
  padding: 10px 28px;
  border-radius: 25px;
  border: 1px solid rgb(12, 13, 12);
  transition: all 0.3s ease;
}

.btn:hover {
  background-color: #000;
  color: #fff;
}

.h-100{
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
  