<template>
   <div class="text-center">
      <h1 style="font-weight: bold; text-transform: uppercase">常見問題</h1>
   </div>
   <div class="text-center">
      <form class="border" @submit.prevent="searchClick">
         <label for="search-input" style="position: absolute; width: 1px; height: 1px; padding: 0; margin: -1px; overflow: hidden"> 搜尋： </label>
         <input type="text" id="search-input" v-model="searchKeyword" placeholder="搜尋" />
         <button id="searchButtom" type="submit">
            <i class="fa-solid fa-magnifying-glass"></i>
         </button>
      </form>
   </div>
   <!-- 呈現問題 -->
   <div class="container-sm">
      <!-- 搜尋的結果 -->
      <div v-if="searchResult !== null">
         <div v-for="question in searchResult" :key="question.id">
            <div class="card">
               <div class="card-body">
                  <h5 class="card-title">{{ question.question }}</h5>
                  <p class="card-text">{{ question.answer }}</p>
                  <button class="btn btn-light" @click="SatisfYes(question.commonQuestionId)">有幫助</button>
                  <button class="btn btn-light" @click="SatisfNo(question.commonQuestionId)">無幫助</button>
               </div>
            </div>
         </div>
      </div>
      <!-- 所有問題 -->
      <!-- <div v-else> -->
      <div class="row">
         <div class="col-3 text-center">
            <div class="accordion accordion-flush" id="accordionExample">
               <div v-for="(category, index) in categoryQ" :key="category.categoryId" class="accordion-item">
                  <div class="accordion-header row" :id="'heading' + index">
                     <button
                        class="accordion-button collapsed"
                        type="button"
                        data-bs-toggle="collapse"
                        :data-bs-target="'#collapse' + index"
                        aria-expanded="true"
                        :aria-controls="'collapse' + index"
                        @click="selectCategory(category.qcategoryId)"
                     >
                        {{ category.categoryName }}
                     </button>
                  </div>
                  <div
                     :id="'collapse' + index"
                     class="accordion-collapse collapse"
                     :aria-labelledby="'heading' + index"
                     data-bs-parent="#accordionExample"
                  >
                     <div class="accordion-body" v-for="question in filteredQuestions" :key="question.commonQuestionId" @click="showAnswer(question)">
                        <p id="qTitle">{{ question.question }}</p>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <!-- 單一問題 -->
         <div class="col-7 answer m-5" v-if="selectedQuestion">
            <div>
               <h3 class="border-bottom">{{ selectedQuestion.question }}</h3>
               <div class="mt-5">{{ selectedQuestion.answer }}</div>
            </div>
            <div class="mt-5">
               <p>
                  是否有回答你的問題?
                  <button type="button" @click="SatisfYes(selectedQuestion.commonQuestionId)" class="btn btn-light ms-2">是</button>
                  <button type="button" @click="SatisfNo(selectedQuestion.commonQuestionId)" class="btn btn-light ms-2">否</button>
               </p>
            </div>
         </div>
      </div>
      <!-- </div> -->
   </div>

   <!-- Button trigger modal -->
   <button id="CustomerQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CustomerQModal" style="display: none">
      顧客提問
   </button>
   <button id="MemberQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MemberQModal" style="display: none">
      會員提問
   </button>
   <button id="AlertModal" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#ThanksModal" style="display: none">
      alertThanks
   </button>

   <CustmorQForm />
   <MemberQForm />
   <AlertModal />
   <!-- <ChatRoom /> -->
</template>

<script setup>
import { ref, onMounted, computed } from "vue";
import axios from "axios";
import CustmorQForm from "../components/CustomerQForm.vue";
import MemberQForm from "../components/MemberQForm.vue";
import AlertModal from "../components/AlertModal.vue";
// import ChatRoom from "../components/ChatRoom.vue";

// 常見問題
const categoryQ = ref([]);
const getQCategoryInfo = async () => {
   await axios
      .get(`https://localhost:7243/CommonQCategory`)
      .then((response) => {
         categoryQ.value = response.data;
      })
      .catch((error) => {
         console.log(error);
      });
};

const questions = ref({});
const getCommonQInfo = async () => {
   await axios
      .get(`https://localhost:7243/CommonQ`)
      .then((response) => {
         questions.value = response.data;
      })
      .catch((error) => {
         console.log(error);
      });
};

// 呈現方式
const selectedQuestion = ref(null);
const selectedCategoryId = ref(null);
const showQuestions = ref(false);

function selectCategory(categoryId) {
   selectedCategoryId.value = categoryId;
   selectedQuestion.value = null;
   showQuestions.value = true;
}

function showAnswer(question) {
   selectedQuestion.value = question;
}

function goBackToList() {
   selectedQuestion.value = null;
}

const filteredQuestions = computed(() => {
   if (!selectedCategoryId.value) {
      return questions.value;
   }
   return questions.value.filter((question) => question.qcategoryId == selectedCategoryId.value);
});

// 搜尋問題
const searchKeyword = ref("");
const searchResult = ref([]);
function searchClick() {
   if (searchKeyword.value === "") {
      searchResult.value = null;
   } else {
      searchResult.value = questions.value.filter((question) => {
         return question.answer.toLowerCase().includes(searchKeyword.value.toLowerCase());
      });
   }
   selectedQuestion.value = null;
   selectedCategoryId.value = null;
}

// 詢問滿意度
const SatisfYes = async (id) => {
   await axios
      .put(`https://localhost:7243/api/Questions/SatisfYes/${id}`)
      .then((response) => {
         document.getElementById("AlertModal").click();
      })
      .catch((error) => {
         console.log(error);
      });
};

const SatisfNo = async (id) => {
   await axios
      .put(`https://localhost:7243/api/Questions/SatisfNo/${id}`)
      .then((response) => {
         document.getElementById("CustomerQForm").click();
      })
      .catch((error) => {
         console.log(error);
      });
};

onMounted(() => {
   getQCategoryInfo();
   getCommonQInfo();
});
</script>

<style scoped>
hr {
   border: none;
   border-top: 1px solid #ccc;
   width: 100%;
   max-width: 400px;
   margin: 0 auto;
}
#search-input {
   width: 200px;
   padding: 10px 10px;
   border-radius: 25px;
   border: none;
   outline: none;
}
#searchButtom {
   position: relative;
   left: -40px;
   padding: 10px;
   background-color: #f2f2f2;
   border: none;
   border-radius: 100%;
   outline: none;
}
#v-pills-home-tab {
   background-color: darkgray;
   margin: 0px;
}
#qTitle {
   margin: 0px;
}
#qTitle:hover {
   background-color: lightgray;
   cursor: pointer;
}
</style>
