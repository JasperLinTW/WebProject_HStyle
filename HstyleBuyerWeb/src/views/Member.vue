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
        })
      })
        .then((response) => {
            return response.json();
        })
        .then( (response) => {
            console.log(response);
        })
        .catch(error => console.error(error));
    },
    logout() {
      axios.post('https://localhost:7243/api/Member/logout')
        .then(response => { 
          // 登出成功，清除用戶端 cookie 或其他相關資料
          this.loggedIn = false;
          this.$router.push('/');
        //   console.log(response)
        })
        .catch(error => {
          console.error(error);
        });
    }
  }
}
  </script>
  <style></style>