<!-- Product.vue -->
<template>
    <div>
      <h1>Welcome to the member page!</h1>
      <p>This is the product page of our app.</p>
    </div>

    <div>
    <form>
      <input type="text" onchange="" v-model="username" placeholder="username">
      <input type="password" v-model="password" placeholder="password">
      <button type="button" @click="login">Login</button>
    </form>
  </div>

</template>





  <script>
// import axios from 'axios';
// import { onMounted } from 'vue';
// export default {
//     setup(){
// let data = reactive({ data:{}});
//         onMounted(){
//             axios.get('').then((res)=>{
//                 datadata = res.data
//             })
//         }
//         return{
//             data
//         }
//     }
// };
// function login() { 
//     // 發送POST請求到伺服器端  目前根本沒有呼叫到
//     $.post("https://localhost:7243/api/Member/LogIn", {
//         account: $("#txtAccount").val(),
//         password: $("#txtPassword").val()
//     }).done(function (response) {
//         alert("111")
//         // 當收到伺服器的回應後，將用戶數據儲存到本地儲存或Cookie中
//         var userData = response.userData;
//         document.cookie = "userId=" + userData.id;
//         document.cookie = "userAccount=" + userData.account;
//         document.cookie = "userName=" + userData.name;
//         // document.cookie = "userEmail=" + userData.email;
//         // document.cookie = "userRole=" + userData.role;
//         // document.cookie = "userPicture=" + userData.picture;

//         // 跳轉到首頁
//         window.location.href = "/";
//     }).fail(function (response) {
//         alert(response.responseText);
//     });
// }

// export default {
//   data() {
//     return {
//       account: '',
//       password: '',
//       userData: null,
//     }
//   },
//   methods: {
//     logIn() {
//       fetch('https://localhost:7243/api/Member/LogIn', {
//         method: 'POST',
//         headers: { 'Content-Type': 'application/json' },
//         body: JSON.stringify({
//           Account: this.account,
//           Password: this.password,          
//         })
//       })
//       .then(response => {const cookie = response.headers.get('my_cookie_name');
//     console.log(cookie);})
//       .then(data => {
        
//         // if (data.userData) {
//         //   this.userData = data.userData;
//           // 登入成功，導向其他頁面
//           // this.$router.push('/dashboard');
//         // } else {
//         //   // 登入失敗，顯示錯誤訊息
//         //   alert('登入失敗: ' + data);
//         // }
//       })
//       .catch(error => console.error(error));
//     },
//   },
// };


import axios from 'axios';

export default {
  methods: {
    login(e) {
      e.preventDefault();
      fetch('https://localhost:7243/api/Member/LogIn', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          "Accept": "application/json",
        },
        body: JSON.stringify({
          'account': 'username',
          'password': 'password'
        })
      })
        .then(response => console.log(response))
        // .then(userData => {
        //   console.log(userData);
        // })
        .catch(error => console.error(error));
    }
  }
};
  </script>
  <style></style>