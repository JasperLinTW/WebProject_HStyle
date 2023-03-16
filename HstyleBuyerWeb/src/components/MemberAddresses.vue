<template>
  <div id="div-t1" style="margin-left: 20px;">
    <h1>我的地址</h1>
    <hr style="margin-left: 20px;">
  </div>

  <div class="container my-5" id="div-t">
    <div class="order-header border-bottom pt-2" id="div-t">
      <div class="row mb-2" id="div-t">
        <div class="col-1 text-center"></div>
        <div class="col-1 text-center">姓名:</div>
        <div class="col-2 text-center">電話號碼:</div>
        <div class="col-1 text-center">地址:</div>
      </div>
    </div>
  </div>
  <div style="text-align: left;" v-for="addressone in address" class="accordion-item" id="a12344">
    <div style="text-align: left;" class="accordion-header row">
      <div id="as" class="col-1 text-center ">{{ addressone.destinationName }}</div>
      <div id="asdf" class="col-1 text-center pt-2">{{ addressone.destinationThe }}</div>
      <div style="text-align: left;" id="asd" class="col-1">{{ addressone.destination }}</div>

      <div><input  id="redio11" type="radio" name="destination" :value="addressone.destinationName">設為常用地址</div>
      

    </div>
  </div>


  <div style="text-align: left; text-indent: 60px">

    <button id="btn-l" type="button" class="btn btn-outline-secondary" data-bs-toggle="modal"
      data-bs-target="#exampleModal111" data-bs-whatever="@mdo">新增地址</button>
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
              <!-- <textarea class="form-control" id="message-text" v-model="destination" require></textarea> -->
              <input type="text" class="form-control" id="message-text" v-model="destination" require>

            </div>
            <div class="mb-3">
              <label for="message-text" class="col-form-label">收件電話:</label>
              <input type="text" class="form-control" id="floatingPassword" v-model="destinationThe" require>
              <!-- <textarea class="form-control" id="message-text" v-model="destinationThe" require></textarea> -->
            </div>
            <div class="form-check">
              <!-- <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault"> -->
              <!-- id 跟 for沒有對稱 -->
              <input style="margin-left:  133px;" class="form-check-input" id="one-checkbox" type="checkbox" />
              <label class="form-check-label" for="flexCheckDefault" id="aa123">設為常用地址</label>
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
const address = ref([]);
const destinationName = ref("");
const destination = ref("")
const destinationThe = ref("")
const destinationCategory = ref("")


const AddAddress = () => {
  axios.post('https://localhost:7243/api/Member/AddAddress', {
    destinationName: destinationName.value,
    destination: destination.value,
    destinationThe: destinationThe.value,
    // destinationCategory: destinationCategory.value,
  }, { withCredentials: true }).then((response) => {
    alert(response.data)
    window.location = "http://localhost:5173/account/MemberAddresses";

  }).catch((err) => {
    console.log(err)
  })
};

const GetAddressInfo = async () => {
  await axios.get("https://localhost:7243/api/Member/GetAddressInfo", { withCredentials: true, })
    .then(response => {
      address.value = response.data;
      //console.log(address.value)
    })
    .catch(error => { console.log(error); });
}
onMounted(() => {
  GetAddressInfo();
});


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

#as {
  margin-left: -15px;
  /* padding: 10px; */
  /* background-color: #5f4646; */
  text-align: left;
}

#asdf {
  margin-left: 80px;
  /* background-color: #eee; */
  text-align: left;
}

#asd {
  margin-left: 100px;
  margin-right: -500px;
  display: inline-block;
  width: 800px;
  /* background-color: #eee; */
}

#a12344 {
  border-bottom: 1px solid rgb(216, 217, 218);
  text-align: left;
  padding-left: 65px;
  padding-right: 133px;
  margin-left: 133px;
  margin-right: 133px;

  /* background-color: #47afc2; */
}

#div-t {
  margin-top: 0px;

  margin-bottom: -30px;

}

#div-t1 {
  margin-top: 0px;

  margin-bottom: -50px;

}

#btn-l {
  margin-top: 1px;
  margin-left: 620px;

}

#flexCheckDefault {
  /* padding-left:  500; */
  margin-left: 133px;

}

#aa123 {
  padding-left: -50px;
  margin-left: -200px;
}
#redio11
{
  /* padding-left:-1000px; */

}
</style>