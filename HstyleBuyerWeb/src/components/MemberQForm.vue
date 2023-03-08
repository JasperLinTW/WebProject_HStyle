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
                     <input class="form-control" type="file" id="imageFile" accept="image/*" @Change="handleUpload" />
                     <div class="fs14">只可上傳一個檔案，且大小需小於4MB的圖檔，如果檔案大大或格式限制無法順利上傳，建議改以連結方式提供。</div>
                     <div v-if="errorMessage">{{ errorMessage }}</div>
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
import { ref, onMounted, watch } from "vue";
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

// 檔案
const file = ref(null);
const errorMessage = ref(null);
const handleUpload = (event) => {
   file.value = event.target.files[0];
};
watch(file, (newFile, oldFile) => {
   if (newFile) {
      const formData = new FormData();
      formData.append("file", newFile);
      const fileSize = newFile.size / 1024 / 1024; // 轉換為 MB
      if (fileSize > 4) {
         // 限制檔案大小為 4 MB
         errorMessage.value = "檔案大小超過限制";
         file.value = null;
      } else {
         errorMessage.value = null;
      }
   }
});

// 送出表單
const qcategoryId = ref([]);
const title = ref([]);
const problemDescription = ref([]);
const askTime = ref([]);
const postMemberQ = async () => {
   if (file.value) {
      const formData = new FormData();
      formData.append("memberId", null);
      formData.append("filePath", null);
      formData.append("file", file.value);
      formData.append("qcategoryId", qcategoryId.value);
      formData.append("title", title.value);
      formData.append("problemDescription", problemDescription.value);
      formData.append("askTime", new Date());

      await axios
         .post("https://localhost:7243/MemberQ", formData, {
            headers: {
               "Content-Type": "multipart/form-data",
            },
            withCredentials: true,
         })
         .then((response) => {
            console.log(response.data);
            console.log("檔案上傳");
            document.getElementById("AlertModal").click();
         })
         .catch((error) => {
            console.log(error);
         });
   } else {
      await axios
         .post(
            "https://localhost:7243/MemberQ",
            {
               memberId: null,
               qcategoryId: qcategoryId.value,
               title: title.value,
               problemDescription: problemDescription.value,
               filePath: null,
               file: null,
               askTime: new Date(),
            },
            { withCredentials: true }
         )
         .then((response) => {
            console.log(response.data);
            console.log("資料上傳");
            document.getElementById("AlertModal").click();
         })
         .catch((error) => {
            console.log(error);
         });
   }
};
// await axios
//    .post(
//       "https://localhost:7243/MemberQ",
//       {
//          memberId: null,
//          qcategoryId: qcategoryId.value,
//          title: title.value,
//          problemDescription: problemDescription.value,
//          filePath: null,
//          file: file.value,
//          askTime: new Date(),
//       },
//       { withCredentials: true }
//    )
//    .then((response) => {
//       console.log(response.data);
//       document.getElementById("AlertModal").click();
//       // alert("感謝您的回饋");
//    })
//    .catch((error) => {
//       console.log(error);
//    });

onMounted(() => {
   getQCategoryInfo();
});
</script>

<style scoped>
.fs14 {
   font-size: 14px;
}
</style>
