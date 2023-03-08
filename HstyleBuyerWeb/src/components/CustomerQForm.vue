<template>
   <!-- Modal -->
   <div class="modal fade" id="CustomerQModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
         <div class="modal-content">
            <div class="modal-header">
               <h5 class="modal-title" id="exampleModalLabel">提交</h5>
               <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
               <div class="mb-3">抱歉該篇文章沒能解決您的問題，如果您願意，請與我們分享缺乏的部分，我們將努力使說明內容更為完善。</div>
               <form @submit.prevent="postCustomerQ">
                  <div class="mb-3">
                     <label for="Qcategory" class="form-label">問題類別</label>
                     <select id="Qcategory" v-model="qcategoryId" class="form-select" aria-label="Default select example" required>
                        <option v-for="(option, index) in categoryQ" :key="index" :value="option.qcategoryId">
                           {{ option.categoryName }}
                        </option>
                     </select>
                  </div>
                  <div class="mb-3">
                     <label for="Qtitle" class="form-label">提問題目</label>
                     <input type="text" id="Qtitle" v-model="title" class="form-control" placeholder="請輸入想要問的題目" required />
                  </div>
                  <div class="mb-3">
                     <label for="Qcontent">提問內容</label>
                     <textarea
                        class="form-control"
                        id="Qcontent"
                        v-model="problemDescription"
                        rows="3"
                        placeholder="請輸入問題內容..."
                        required
                     ></textarea>
                  </div>
                  <button type="submit" class="btn btn-primary">送出</button>
               </form>
            </div>
         </div>
      </div>
   </div>
   <button id="AlertModal" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#ThanksModal" style="display: none">
      alertThanks
   </button>
   <AlertModal />
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";
import AlertModal from "../components/AlertModal.vue";

const categoryQ = ref([]);
const getQCategoryInfo = async () => {
   await axios
      .get("https://localhost:7243/CommonQCategory")
      .then((response) => {
         categoryQ.value = response.data;
      })
      .catch((error) => {
         console.log(error);
      });
};

const qcategoryId = ref([]);
const title = ref([]);
const problemDescription = ref([]);
const askTime = ref([]);
const postCustomerQ = async () => {
   await axios
      .post("https://localhost:7243/CustomerQ", {
         memberId: null,
         qcategoryId: qcategoryId.value,
         title: title.value,
         problemDescription: problemDescription.value,
         filePath: null,
         file: null,
         askTime: new Date(),
      })
      .then((response) => {
         // console.log(response.data);
         document.getElementById("AlertModal").click();
         // window.location = "http://localhost:5173/Questions";
      })
      .catch((error) => {
         console.log(error);
      });
};

onMounted(() => {
   getQCategoryInfo();
});
</script>

<style scoped></style>
