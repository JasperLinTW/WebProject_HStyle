<!-- Blog.vue -->
<template>


<div>
  <h1>
    <P>我的帳號</P>
  </h1>
</div>
<div class="login_tabs__10-Vj">
  <button type="button" class="login_tab__2K1tt  login_active__14Nkw">登入</button>
  <button type="button" class="login_tab__2K1tt ">會員註冊</button>
  <div class="login_line__3_Wxt" style="left: 0px; width: 98px;"></div>
</div>
<div >
    <form >
      <input type="text" onchange="" v-model="username" placeholder="username">
      <input type="password" v-model="password" placeholder="password">


      
    </form>
  </div>

<div class="d-grid gap-2 col-6 mx-auto">
  <button type="button" class="btn btn-outline-dark btn-lg" @click="login">登　　入</button>
  <button type="button" class="btn btn-outline-dark btn-lg" @click="Logout">登　　出</button>
</div>

<div>
    <h3>忘記密碼</h3>
</div>
</template>
  
<script>
export default {
    data(){
        return{
            username: "",
            password: "",

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
        credentials: 'include',

        body: JSON.stringify({
          'account': this.username,
          'password': this.password
        }),
      })
        .then((response) => {
        })
        .catch(error => console.error(error));
    },
  }
}

</script>
<style>
.login_tabs__10-Vj {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    border-bottom: 1px solid #a6a6a6;
    position: relative;
}

.Layout_container__3yEil {
    width: 100%;
    font-size: 1.4rem;
    padding-bottom: 100px;
}

</style>