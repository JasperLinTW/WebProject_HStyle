<template>
   <div style="text-align: center">
      <h1 style="font-weight: bold; text-transform: uppercase">常見問題</h1>
   </div>
   <div style="text-align: center">
      <form class="border">
         <label
            for="search-input"
            style="position: absolute; width: 1px; height: 1px; padding: 0; margin: -1px; overflow: hidden; clip: rect(0, 0, 0, 0); border: 0"
         >
            搜尋：
         </label>
         <input
            type="text"
            id="search-input"
            name="search"
            placeholder="搜尋"
            style="width: 200px; padding: 10px 25px; border-radius: 25px; border: none; outline: none"
         />
         <button
            type="submit"
            style="position: relative; left: -40px; padding: 10px; background-color: #f2f2f2; border: none; border-radius: 50%; outline: none"
         >
            <i class="fa-solid fa-magnifying-glass"></i>
            <!-- <img src="search-icon.png" alt="search icon" style="width: 20px; height: 20px" /> -->
         </button>
      </form>
   </div>

   <!-- 嘗試5 -->
   <div>
      <div class="category">
         <h3>問題分類</h3>
         <p v-for="category in categoryQ" :key="category.qcategoryId" @click="selectCategory(category.qcategoryId)">
            {{ category.categoryName }}
         </p>
         <div class="question-list" v-if="showQuestions">
            <h3>問題列表</h3>
            <p v-for="question in filteredQuestions" :key="question.commonQuestionId" @click="showAnswer(question)">
               {{ question.question }}
            </p>
         </div>
         <div class="answer" v-if="selectedQuestion">
            <h3>{{ selectedQuestion.question }}</h3>
            <p>{{ selectedQuestion.answer }}</p>
            <div>
               <p>是否有回答你的問題?</p>
               <button type="button" @click="SatisfYes(selectedQuestion.commonQuestionId)" class="btn btn-light">是</button>
               <button type="button" @click="SatisfNo(selectedQuestion.commonQuestionId)" class="btn btn-light">否</button>
            </div>
         </div>
      </div>
   </div>
   <!-- Button trigger modal -->
   <button id="CustomerQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CustomerQModal" style="display:none;">顧客提問</button>
   <button id="MemberQForm" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MemberQModal" style="display:none;">會員提問</button>

   <CustmorQForm />
   <MemberQForm />
</template>

<script setup>
import { ref, onMounted, computed } from "vue";
import axios from "axios";
import CustmorQForm from "../components/CustomerQForm.vue";
import MemberQForm from "../components/MemberQForm.vue";

const categoryQ = ref([]);
const getQCategoryInfo = async () => {
   await axios
      .get("https://localhost:7243/CommonQCategory")
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

// test5
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
         alert("感謝您的回饋!");
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
