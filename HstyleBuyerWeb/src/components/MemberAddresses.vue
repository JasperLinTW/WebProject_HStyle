<template>
  <div>
    <p>會員地址管理頁</p>
  </div>

  <h1>我的地址</h1>
  <div style="text-align: left; text-indent: 60px">

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal111"
      data-bs-whatever="@mdo">新增地址</button>
  </div>
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@fat">Open modal for @fat</button>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@getbootstrap">Open modal for @getbootstrap</button> -->

  <div class="modal fade" id="exampleModal111" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">新增地址</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="recipient-name" class="col-form-label">姓名:</label>
              <input type="text" class="form-control" id="recipient-name" v-model="destinationName" require>
            </div>
            <div class="mb-3">
              <label for="message-text" class="col-form-label">收件地:</label>
              <textarea class="form-control" id="message-text" v-model="destination" require></textarea>
            </div>
            <div class="mb-3">
              <label for="message-text" class="col-form-label">收件電話:</label>
              <input type="text" class="form-control" id="floatingPassword" v-model="destinationThe" require>

              <!-- <textarea class="form-control" id="message-text" v-model="destinationThe" require></textarea> -->
            </div>
            <!-- <div class="mb-3">
            <label style="text-align: left;" for="message-text" class="col-form-label">四大超商收件:</label>
            <input type="text" class="form-control" id="floatingPassword" v-model="destinationCategory" require>
            <textarea class="form-control" id="message-text" ></textarea>
          </div> -->
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button>
          <button type="button" class="btn btn-primary" @click="AddAddress">儲存</button>
        </div>
      </div>
    </div>
  </div>
</template>
    


<script setup>

import { onMounted, ref } from 'vue';

import axios from 'axios';

const destinationName = ref("");
const destination = ref("")
const destinationThe = ref("")
const destinationCategory = ref("")


const AddAddress = () => {
  axios.post('https://localhost:7243/api/Member/AddAddress', {
    destinationName: destinationName.value,
    destination: destination.value,
    destinationThe: destinationThe.value,
    destinationCategory: destinationCategory.value,
  }, { withCredentials: true }).then((response) => {
    console.log(response.data)
    window.location = "http://localhost:5173/account/MemberAddresses";

  }).catch((err) => {
    console.log(err)
  })
};


// onMounted(() => {
//     AddAddress();
// });


</script>
<style scoped>
h1 {
  text-align: left;
  text-indent: 20px
}

label {
  text-align: left;
  text-indent: 20px
}

.col-form-label {
  text-align: left;


}
</style>