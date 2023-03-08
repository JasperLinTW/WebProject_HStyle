<template>
    <div class="container mt-5 login px-10">
        <div class="row">
            <div class="col-md-12 mt-5 mb-4 fz-big">會員登入</div>
            <div class="col-md-6 pb-2 border-bottom">
                <button class="btn-underline" @click="showLogin = false" :class="{ active: !showLogin }">新會員註冊</button>
            </div>
            <div class="col-md-6 border-bottom">
                <button class="btn-underline" @click="showLogin = true" :class="{ active: showLogin }">會員登入</button>
            </div>
            <div v-if="showLogin" class="m-0 p-0">
                <div class="mt-3">
                    <div class="form-floating mb-3">
                        <input type="text" class="form-control" id="floatingInput" v-model="account" required>
                        <label for="floatingInput">帳號</label>
                    </div>
                    <div class="form-floating">
                        <input type="password" class="form-control" id="floatingPassword" v-model="password" require>
                        <label for="floatingPassword">密碼</label>
                    </div>
                </div>
                <div class="col-md-12 mt-3">
                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-6"><button type="button" @click="login" class="btn mt-3 w-75">登入</button></div>
                        <div class="col-md-3">
                            <div class="pt-4 mt-1 text-start fz-sm">忘記密碼?</div>
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
        window.location = "http://localhost:5173";

    }).catch((err) => {
        console.log(err)
    })
};

const getMemberId = () => {
    axios.get('https://localhost:7243/api/Member/id', { withCredentials: true, })
        .then((response) => {
            console.log(response.data);
        })
        .catch((error) => {
            console.error(error);
        });
};

const getCartInfo = async () => {
    await axios.get("https://localhost:7243/api/Cart", { withCredentials: true, })
        .then(response => { console.log(response.data); })
        .catch(error => {
            console.log(error.response.status);
            if (error.response.status === 401) {
                window.location = "http://localhost:5173/login"
            }
        });
}

const showLogin = ref(true);






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
    content: '';
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
}</style>
  