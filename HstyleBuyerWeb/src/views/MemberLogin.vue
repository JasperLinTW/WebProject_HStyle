<!-- Blog.vue -->
<template>
    <div>
      <h1>Welcome to the Blog page!</h1>
      <p>This is the Blog page of our app.</p>
      <input type="text" onchange="" v-model="username" placeholder="username">
      <input type="password" v-model="password" placeholder="password">
      <button type="button" @click="login">Login</button>
    </div>
    <!-- <div class="checkbox">
	<label>
		<input class="form-check-input" type="checkbox" value="true" id="chkKeepLogin" v-model="form.KeepLogin">
		保持登入
	</label>

</div>  -->
</template>
  
<script>
  
  export default {
    data(){
        return{
            username: "",
            password: "",
            name:"",
            Email:"",
            Account:"",
            PhoneNumber:"",
            Address:"",
            gender:"",
            Birthday:"",
            EncryptedPassword:"",
            MailCode:1,
            chkKeepLogin:"",
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

<style></style>