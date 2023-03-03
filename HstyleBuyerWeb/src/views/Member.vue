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
      <button type="button" @click="Logout">Logout</button>

    </form>
  </div>

</template>


  <script>

import axios from 'axios';

export default {
    data(){
        return{
            username: "",
            password: ""
        }
    },
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
          'account': this.username,
          'password': this.password
        }),
        credentials: 'same-origin' //測試 本來沒有加
      })
        .then((response) => {
            return response.json();
        })
        .then( (response) => {
            // console.log(response)
        })
        .catch(error => console.error(error));
    },
    Logout(e){
        e.preventDefault()
    fetch('https://localhost:7243/api/Member/LogOut', {
        method: 'POST',
        headers: {     
            'Content-Type': 'application/json',       
            "Accept": "application/json",
        },
        body: JSON.stringify({
          
        }),
        credentials: 'same-origin'
        })
        .then((response) => {
            return response.json();
        })
        .then(response => {
            console.log(response)
        }).catch(error => {
            console.error(error)// 網路錯誤或其他錯誤處理
        })
    }
  }
}
  </script>
  <style></style>