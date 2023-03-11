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
                <div class="input-group input-group-sm mb-3">
                <span class="input-group-text" id="inputGroup-sizing-sm">用戶名：</span>
                <input type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" v-model="member.name">
                </div>
                <div class="input-group input-group-sm mb-3">
                <span class="input-group-text" id="inputGroup-sizing-sm">手機號碼：</span>
                <input type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" v-model="member.phoneNumber">
                </div>
                <div class="input-group input-group-sm mb-3">
                <span class="input-group-text" id="inputGroup-sizing-sm">地址：</span>
                <input type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm" v-model="member.address">
                </div>
                
                <!-- <input type="text" name="" id="" :value="member.gender"> -->
<!-- 
                <div class="text-center " >
                <input class="form-check-input " type="radio" name="gender" id="male" value="true" v-model="member.gender">
                <label class="form-check-label" for="male">
                    男
                </label>
                </div>
                <div class="text-center">
                <input class="form-check-input" type="radio" name="gender" id="female" value="false" v-model="member.gender">
                <label class="form-check-label" for="female">
                    女
                </label>
                </div> -->

                <!-- <input type="text" name="" id="" :value="member.phoneNumber" v-model="phoneNumber">
                <input type="text" name="" id="" :value="member.address" v-model="address">
                <input type="text" name="" id="" :value="member.gender" v-model="gender">
                <input type="text" name="" id="" :value="member.birthday" v-model="birthday"> -->

                <li class="list-group-item"  required >用戶名：{{ member.name }}</li>
                <li class="list-group-item">郵箱：{{ member.email }}</li>
                <li class="list-group-item">註冊時間：{{ member.jointime }}</li>
                <li class="list-group-item">帳號：{{ member.account }}</li>
                <li class="list-group-item">性別：{{ member.gender }}</li>
                <li class="list-group-item">生日：{{ member.birthday }}</li>
                <li class="list-group-item">地址：{{ member.address }}</li>
                <li class="list-group-item">優惠數量：{{ member.totalH }}</li>

            </ul>
        </div>

        <div class="d-flex justify-content-center align-items-center ">
            <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button> -->
            <button type="button" class="btn btn-primary"  @click="EditMember">更新會員資料</button>
        </div>



    </div>
</template>
    
<script setup>

import { onMounted, ref } from 'vue';
import axios from 'axios';

const member = ref({});  
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
    console.log(member.value)
    axios.post('https://localhost:7243/api/Member/EditMember', {
        name: member.value.name,
        phoneNumber: member.value.phoneNumber,
        address: member.value.address,
        // gender: member.value.gender,
    }, { withCredentials: true }).then((response) => {
        console.log(response.data)
        window.location = "http://localhost:5173/account/MemberProfile";

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