<template>
    <div class="login">


        <label>
            帳號:
            <input type="text" v-model="account" required>
        </label>
        <label>
            密碼:
            <input type="password" v-model="password" required>
        </label>
        <button type="button" @click="login" class="btn btn-light">登入</button>
        <button type="button" @click="logout" class="btn btn-light">登出</button>
        <button type="button" @click="getMemberId" class="btn btn-light">取id</button>

    </div>
</template>
  
<script setup>
import { ref } from 'vue';
import axios from 'axios';
const account = ref("");
const password = ref("")
const login = () => {
    axios.post('https://localhost:7243/api/Member/LogIn', {
        account: account.value,
        password: password.value
    }, { withCredentials: true }).then((response) => {
        console.log(response.data)

    }).catch((err) => {
        console.log(err)
    })
};
const logout = () => {
    axios.post('https://localhost:7243/api/Member/LogOut', {}, {
        withCredentials: true,
    })
        .then((response) => {
            console.log(response.data);
        })
        .catch((error) => {
            console.error(error);
        });
};
const getMemberId = () => {
    axios.get('https://localhost:7243/api/Member/id', {withCredentials: true,})
        .then((response) => {
            console.log(response.data);
        })
        .catch((error) => {
            console.error(error);
        });
};








</script>
  
<style scoped>
.login {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
    height: 500px;
}

h1 {
    margin-bottom: 20px;
}


label {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 5px;
}

input {
    padding: 10px;
    border-radius: 5px;
    border: 1px solid #ccc;
    width: 100%;
    max-width: 300px;
}

button {
    padding: 10px 20px;
    border-radius: 5px;
    border: none;
    cursor: pointer;
}
</style>
  