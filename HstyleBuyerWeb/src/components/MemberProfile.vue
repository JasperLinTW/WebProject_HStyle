<template>
    <div>
        <h1>會員資料</h1>
    <hr>
        
    <label for="firstName">名</label> .
    <input type="text" placeholder="名 *" id="firstName" required="">
        信箱 {{member.email}},
        手機 {{member.phoneNumber}},
        性別 {{member.gender}},
        生日 {{member.birthday}},
        加入會員時間 {{member.jointime}},
        優惠幣數量 {{member.totalH}},
        <table class="table table-hover"> 信箱 {{member.email}},</table>

        <div class="row bg-dark text-white font-weight-bold  py-2">
                            <div class="col-1"></div>
                            <div class="col-2 text-center">名稱  {{member.name}},</div>
                            <div class="col-2 text-center">規格帳號 {{ member.account }},</div>
                            <div class="col-2 text-center">單價</div>
                            <div class="col-2 text-center">數量</div>
                            <div class="col-2 text-center">小計</div>
                            <div class="col-1"></div>
                        </div>





    </div>


</template>
    
<script setup>

import { onMounted, ref } from 'vue';
import axios from 'axios';

const member = ref([]);


const getMemberInfo = async () => {
    await axios.get("https://localhost:7243/api/Member",{ withCredentials: true, })
        .then(response => {
            member.value = response.data;
            console.log(member.value)
        })
        .catch(error => { console.log(error); });
}


onMounted(() => {
    getMemberInfo();
});


</script>
<style>

h1 {
  text-align: left;
  text-indent: 20px
}
</style>