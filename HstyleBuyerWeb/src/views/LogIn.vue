<!-- Blog.vue -->
<template>


<div>
  <h1>
    <P>我的帳號</P>
  </h1>
</div>
<div class="login_tabs__10-Vj">
  <button type="button" class="login_tab__2K1tt ">登入</button>
  <button type="button" class="login_tab__2K1tt  login_active__14Nkw">會員註冊</button>
  <div class="login_line__3_Wxt" style="left: 98px; width: 136px;"></div>
</div>
<div >

      <form>
  <div class="d-grid gap-2 col-6 mx-auto" >
    <label for="exampleInputEmail1" class="form-label" ><h3>帳號</h3></label>
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" onchange="" v-model="username" placeholder="username">
    <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
  </div>
  <div class="d-grid gap-2 col-6 mx-auto">
    <label for="exampleInputPassword1" class="form-label"><h3>密碼</h3></label>
    <input type="password" class="form-control" id="exampleInputPassword1" v-model="password" placeholder="password">
  </div>
  <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <!-- <label class="form-check-label" for="exampleCheck1">Check me out</label> -->
  </div>
  <!-- <button type="submit" class="btn btn-primary">Submit</button> -->
</form>

      
   
  </div>

<div class="d-grid gap-2 col-6 mx-auto">
  <button type="button" class="btn btn-outline-dark btn-lg" @click="login">登　　入</button>
  <!-- <button type="button" class="btn btn-outline-dark btn-lg" @click="Logout">登　　出</button> -->
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
.login_tabs__10-Vj .login_tab__2K1tt {
    font-size: 1.4rem;
    font-weight: 700;
    text-transform: uppercase;
    padding: 10px;
    position: relative;
    cursor: pointer;
    opacity: .5;
    transition: all .4s;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}
.login_tabs__10-Vj .login_tab__2K1tt {
    font-size: 1.8rem;
    padding: 10px 30px;
}
.login_tabs__10-Vj .login_line__3_Wxt {
    height: 3px;
    position: absolute;
    bottom: -2px;
    background-color: #3a3a3a;
    transition: all .4s;
}
</style>