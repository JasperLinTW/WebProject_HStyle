<template>
   <!-- Modal -->
   <div class="modal fade" id="MemberQModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
         <div class="modal-content">
            <div class="modal-header">
               <h5 class="modal-title" id="exampleModalLabel">聯絡客服</h5>
               <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
               <div>請提供以下資料，我們的客服將盡快回復。</div>
               <form @submit.prevent="postMemberQ">
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
                        placeholder="請協助加以描述您遇到的問題..."
                        rows="3"
                        required
                     ></textarea>
                  </div>
                  <div class="mb-3">
                     <label for="imageFile" class="form-label">圖片上傳</label>
                     <input class="form-control" type="file" id="imageFile" accept="image/*" />
                     <div class="fs14">只可上傳一個檔案，且大小需小於4MB的圖檔，如果檔案大大或格式限制無法順利上傳，建議改以連結方式提供。</div>
                  </div>
                  <button type="submit" class="btn btn-primary">送出</button>
               </form>
            </div>
         </div>
      </div>
   </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";
const userId = 0;

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

// 檔案上傳
// todo
const fileUploader = document.querySelector("#imageFile");
// fileUploader.addEventListener('change', (e) => {
//   e.target.files; // FileList object
//   e.target.files[0]; // File Object (Special Blob)
// });

// 送出表單
const qcategoryId = ref([]);
const title = ref([]);
const problemDescription = ref([]);
const askTime = ref([]);
const filePath = ref([]);
const postMemberQ = async () => {
   await axios
      .post("https://localhost:7243/CustomerQ", {
         memberId: userId,
         qcategoryId: qcategoryId.value,
         title: title.value,
         problemDescription: problemDescription.value,
         filePath: null,
         askTime: new Date(),
      })
      .then((response) => {
         console.log(response.data);
         alert("感謝您的回饋");
      })
      .catch((error) => {
         console.log(error);
      });
};

onMounted(() => {
   getQCategoryInfo();
});
</script>

<style scoped>
.fs14 {
   font-size: 14px;
}
</style>
