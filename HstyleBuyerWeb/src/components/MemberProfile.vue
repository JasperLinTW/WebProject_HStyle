<template>
    <div>
        <h1>會員資料</h1>
        <hr>

    <form class="row g-3">
  <div class="col-md-4">
    <label for="validationDefault01" class="form-label">用戶名：</label>
    <input type="text" class="form-control" id="validationDefault01" v-model="member.name"  required>
  </div>
  <div class="col-md-4">
    <label for="validationDefault02" class="form-label">手機號碼：</label>
    <input type="text" class="form-control" id="validationDefault02" v-model="member.phoneNumber" required>
  </div>
  <div class="col-md-4">
    <label for="validationDefaultUsername" class="form-label">地址：</label>
    <div class="input-group">
      <input type="text" class="form-control" id="validationDefaultUsername"  aria-describedby="inputGroupPrepend2" v-model="member.address" required>
    </div>
  </div>
  <div class="col-md-6">
    <label for="validationDefault03" class="form-label">郵箱：</label>
    <input type="text" class="form-control" id="validationDefault03" v-model="member.email" readonly required>
  </div>
  <div class="col-md-6">
    <label for="validationDefault03" class="form-label">帳號：</label>
    <input type="text" class="form-control" id="validationDefault03" v-model="member.account" readonly required>
  </div>
  <div class="col-md-6">
    <label for="validationDefault03" class="form-label">性別：男</label>
    <input type="text" class="form-control" id="validationDefault03" v-model="member.gender" readonly required>
  </div>
  <div class="col-md-6">
    <label for="validationDefault03" class="form-label">生日：</label>
    <input type="text" class="form-control" id="validationDefault03" v-model="member.birthday" readonly required>
  </div>
  <div class="col-md-6">
    <label for="validationDefault03" class="form-label">H幣的總額：</label>
    <input type="text" class="form-control" id="validationDefault03" v-model="member.totalH" readonly required>
  </div>

  

  <div class="col-md-6">
  <button class="btn btn-primary " type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample999" aria-expanded="false" aria-controls="collapseExample">
    更改密碼
  </button>
<div class="collapse" id="collapseExample999">
  <div class="card card-body">
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">原始密碼</label>
    <input type="account" class="form-control" id=""  v-model="oldPassword" required>
    <!-- <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> -->
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">新密碼</label>
    <input type="password" class="form-control" id="" v-model="newPassword" required>
  </div>
  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">確認新密碼</label>
    <input type="password" class="form-control" id="" v-model="newPassword2" required>
  </div>
  <button type="button" class="btn btn-primary" @click="ResetPassword1 ">更新密碼</button>
</form>
  </div>
</div>    
</div>

  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck2" required>
      <label class="form-check-label" for="invalidCheck2">
        同意條款和條件
      </label>
    </div>
  </div>
        <div class="col-12">
    <button class="btn btn-primary" type="button" @click="EditMember">更新會員資料</button>
  </div>
</form>


    </div>
</template>
    
<script setup>

import { onMounted, ref } from 'vue';
import axios from 'axios';
import { eventBus } from "../mybus";

const member = ref({});  
const name = ref("");
const phoneNumber = ref("");
const address = ref("");
const gender = ref("");
const birthday = ref("");
const Resetaccount=ref("");
const password=ref("");
const EncryptedPassword=ref("");
const oldPassword=ref("");
const newPassword=ref("");
const newPassword2=ref("");
const getMemberInfo = async () => {
    await axios.get("https://localhost:7243/api/Member", { withCredentials: true, })
        .then(response => {
            member.value = response.data;
            console.log(member.value)
        })
        .catch(error => { console.log(error); });
}

eventBus.on("ResetPassword", () => {
    getMemberInfo();

});

const EditMember = () => {
    console.log(member.value)
    axios.post('https://localhost:7243/api/Member/EditMember', {
        name: member.value.name,
        phoneNumber: member.value.phoneNumber,
        address: member.value.address,
        // gender: member.value.gender,
    }, { withCredentials: true })
    .then((response) => {
        console.log(response.data)
        alert("更新成功")
    if(!response.ok){
        alert(err.data)
    }else{
        console.log(response.data)
        window.location = "http://localhost:5173/account/MemberProfile";}

    }).catch((err) => {
        console.log(err)
    })
};


const ResetPassword1 = () => {
    axios.post(`https://localhost:7243/api/Member/ResetPassword?oldPassword=${oldPassword.value}&newPassword=${newPassword.value}&newPassword2=${newPassword2.value}`,{},
     { withCredentials: true })
    .then((response) => {
        alert(response.data)
        
        if(response.data==="修改成功"){
        eventBus.emit("ResetPassword"); 
        window.location="http://localhost:5173/"}
    }).catch((err) => {
       
    })
};

onMounted(() => {
    getMemberInfo();
});


</script>
<style scoped>
h1 {
    text-align: left;
    text-indent: 20px
}
</style>