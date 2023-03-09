<template>
    <div>
        <h1>會員資料</h1>
        <hr>


        <div class="row bg-dark text-white font-weight-bold  py-2">
            <div class="col-1"></div>
            <div class="col-2 text-center">名稱 {{ member.name }},</div>
            <div class="col-2 text-center">規格帳號 {{ member.account }},</div>
            <div class="col-2 text-center">單價</div>
            <div class="col-2 text-center">數量</div>
            <div class="col-2 text-center">小計</div>
            <div class="col-1"></div>
        </div>


        <div>
            <ul class="list-group list-group-flush">
                <input type="text" name="" id="" :value="member.name">
                <li class="list-group-item">用戶名：{{ member.name }}</li>
                <li class="list-group-item">郵箱：{{ member.email }}</li>
                <!-- <li class="list-group-item">註冊時間：{{ member.jointime }}</li> -->
                <li class="list-group-item">帳號：{{ member.account }}</li>
                <li class="list-group-item">性別：{{ member.gender }}</li>
                <li class="list-group-item">生日：{{ member.birthday }}</li>
                <li class="list-group-item">地址：{{ member.address }}</li>
                <li class="list-group-item">優惠數量：{{ member.totalH }}</li>

            </ul>
        </div>

        <div class="d-flex justify-content-center align-items-center ">
            <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button> -->
            <button type="button" class="btn btn-primary">更新會員資料</button>
        </div>



    </div>
</template>
    
<script setup>

import { onMounted, ref } from 'vue';
import axios from 'axios';

const member = ref([]);
const name = ref("");
const phoneNumber = ref("");
const address = ref("");
const gender = ref("");
const birthday = ref("");


const getMemberInfo = async () => {
    await axios.get("https://localhost:7243/api/Member", { withCredentials: true, })
        .then(response => {
            member.value = response.data;
            console.log(member.value)
        })
        .catch(error => { console.log(error); });
}

const EditMember = () => {
    axios.post('https://localhost:7243/api/Member/EditMember', {
        name: name.value,
        phoneNumber: phoneNumber.value,
        address: address.value,
        gender: gender.value,
        birthday: birthday.value,
    }, { withCredentials: true }).then((response) => {
        console.log(response.data)
        window.location = "http://localhost:5173/account/MemberAddresses";

    }).catch((err) => {
        console.log(err)
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