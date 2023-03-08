<template>
   <div style="text-align: center">
      <h1 style="font-weight: bold; text-transform: uppercase">常見問題</h1>
   </div>
   <div style="text-align: center">
      <form class="border">
         <input type="text" id="search-input" v-model="keyword" placeholder="搜尋" />
         <button id="searchButtom" type="submit" style="" @click="searchClick">
            <i class="fa-solid fa-magnifying-glass"></i>
         </button>
      </form>
   </div>

   <!-- 常見問題 -->
   <div class="container-sm">
      <div class="row">
         <div class="col-4">
            <div class="category">
               <h4>問題分類</h4>
               <p v-for="category in categoryQ" :key="category.qcategoryId" @click="selectCategory(category.qcategoryId)">
                  {{ category.categoryName }}
               </p>
            </div>
            <div class="question-list border-top" v-if="showQuestions">
               <h4>問題列表</h4>
               <p v-for="question in filteredQuestions" :key="question.commonQuestionId" @click="showAnswer(question)">
                  {{ question.question }}
               </p>
            </div>
         </div>
         <div class="col-8">
            <div class="answer m-5" v-if="selectedQuestion">
               <div>
                  <h3>{{ selectedQuestion.question }}</h3>
                  <div>{{ selectedQuestion.answer }}</div>
               </div>
               <div class="mt-5">
                  <p>是否有回答你的問題? 
                  <button type="button" @click="SatisfYes(selectedQuestion.commonQuestionId)" class="btn btn-light ms-2">是</button>
                  <button type="button" @click="SatisfNo(selectedQuestion.commonQuestionId)" class="btn btn-light ms-2">否</button>
                  </p>
               </div>
            </div>
         </div>
      </div>
   </div>

   <!-- 常見問題 test
   <div>
      <div class="category">
         <h3>問題分類</h3>
         <p v-for="category in categoryQ" :key="category.qcategoryId" @click="selectCategory(category.qcategoryId)">
            {{ category.categoryName }}
         </p>
      </div>
      <div class="question-list border-top" v-if="showQuestions">
         <h3>問題列表</h3>
         <p v-for="question in filteredQuestions" :key="question.commonQuestionId" @click="showAnswer(question)">
            {{ question.question }}
         </p>
      </div>
      <div class="answer border-top" v-if="selectedQuestion">
         <h3>{{ selectedQuestion.question }}</h3>
         <p>{{ selectedQuestion.answer }}</p>
         <div>
            <p>是否有回答你的問題?</p>
            <button type="button" @click="SatisfYes(selectedQuestion.commonQuestionId)" class="btn btn-light">是</button>
            <button type="button" @click="SatisfNo(selectedQuestion.commonQuestionId)" class="btn btn-light">否</button>
         </div>
      </div>
   </div> -->

   <!-- Button trigger modal -->
   <button id="CustomerQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CustomerQModal" style="display: none">
      顧客提問
   </button>
   <button id="MemberQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MemberQModal" style="display: blod">
      會員提問
   </button>
   <button id="AlertModal" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#ThanksModal" style="display: none">
      alertThanks
   </button>

   <CustmorQForm />
   <MemberQForm />
   <AlertModal />
</template>

<script setup>
import { ref, onMounted, computed } from "vue";
import axios from "axios";
import CustmorQForm from "../components/CustomerQForm.vue";
import MemberQForm from "../components/MemberQForm.vue";
import AlertModal from "../components/AlertModal.vue";

const categoryQ = ref([]);
const getQCategoryInfo = async () => {
   await axios
      .get(`https://localhost:7243/CommonQCategory`)
      .then((response) => {
         categoryQ.value = response.data;
         console.log(response.data);
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
         console.log(response.data);
      })
      .catch((error) => {
         console.log(error);
      });
};

// 搜尋問題
// const keyword = ref("");
const searchClick = async () => {
   console.log(keyword);
   await axios
      .get(`https://localhost:7243/CommonQCategory?keyword=${keyword}`)
      .then((response) => {
         categoryQ.value = response.data;
         console.log(response.data);
      })
      .catch((error) => {
         console.log(error);
      });
};
// document.getElementById("searchButtom").click(
//    await axios
//       .get(`https://localhost:7243/CommonQ?keyword=${keyword}`)
//       .then((response) => {
//          questions.value = response.data;
//          console.log(response.data);
//       })
//       .catch((error) => {
//          console.log(error);
//       })
// );

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
   border-radius: 50%;
   outline: none;
}

.container {
   display: flex;
   flex-direction: row;
   align-items: center;
   text-align: center;
   margin: 0 auto;
   width: 80%;
   max-width: 800px;
   padding: 50px 0;
   font-size: 20px;
   line-height: 1.5;
}
.container.column {
   flex-direction: column;
}
.container hr {
   display: none;
   margin: 20px 0;
   border-top: 2px solid black;
}
.container.column hr {
   display: block;
   margin: 20px auto;
   width: 80%;
   max-width: 600px;
}
.container p {
   flex: 1;
}
.container .clickable {
   cursor: pointer;
}
.container .clickable:hover {
   font-weight: bold;
}
</style>
