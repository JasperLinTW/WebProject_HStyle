<template>
    <div>
        <p>會員資料</p>
    </div>

    <!-- <div v-for="m in member" class="row border-bottom py-3">
                    <div class="col-1"></div>
                    <div class="col-2">{{  }}</div>
                    <div class="col-2">{{ product.color }}</div>
                    <div class="col-2">{{ product.unitPrice }}</div>
                    <div class="col-2">{{ product.quantity }}</div>
                    <div class="col-2">{{ product.subTotal }}</div>
    </div> -->



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
</script>
<style></style>