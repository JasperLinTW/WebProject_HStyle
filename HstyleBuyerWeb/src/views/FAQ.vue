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
   <div class="container-sm" style="min-height: 800px">
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

   <!-- 聊天室 -->
   <div>
      <div class="chat-button" @click="toggleChat">
         <span>{{ showChat ? "關閉聊天室" : "聊天室" }}</span>
      </div>
      <div class="chat-window" :class="{ show: showChat }">
         <div class="chat-header">
            <h6>聊天室</h6>
            <button class="close-button" @click="toggleChat">x</button>
         </div>
         <div class="chat-content">
            <ChatRoom v-if="showChat" />
         </div>
      </div>
   </div>
   
   <!-- 客服聊天室 -->
   <router-link to="/ServerChatRoom" class="text-decoration-none text-dark" style="display: none">客服回覆</router-link>

   <!-- <div style="position: fixed; top: 80%; left: 92%">
      <div class="row">
         <div class="border">
            <component v-if="showChat" :is="chatComponent" style="position: fixed; top: 70%; left: 70%"><ChatRoom /></component>
         </div>
         <button class="btn btn-warning" @click="toggleChat">{{ showChat ? "關閉聊天室" : "聊天室" }}</button>
      </div>
   </div> -->
   <!-- 客服聊天室 -->
   <router-link to="/ServerChatRoom" class="text-decoration-none text-dark" style="display: none">客服回覆</router-link>

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
import ChatRoom from "../components/ChatRoom.vue";
// import io from "socket.io-client";

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

// 聊天室
const showChat = ref(false);
const chatSocket = ref(null);
function toggleChat() {
   showChat.value = !showChat.value;
   if (showChat.value) {
      // 開啟聊天室時建立連線
      chatSocket.value = new WebSocket("wss://localhost:7243/ws");
   } else {
      // 關閉聊天室時中斷連線
      chatSocket.value.close();
      chatSocket.value = null;
   }
}
const chatComponent = computed(() => {
   return showChat.value ? "ChatRoom" : null;
});

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
/* 聊天室的樣式 */
.chat-button {
   position: fixed;
   bottom: 20px;
   right: 20px;
   z-index: 9999;
   background-color: #46a3ff;
   color: #fff;
   padding: 10px;
   border-radius: 5px 0 0 5px;
   cursor: pointer;
}
.chat-window {
   position: fixed;
   bottom: 0;
   right: 0;
   z-index: 9998;
   width: 300px;
   height: 400px;
   border-radius: 5px 0 0 0;
   background-color: #fff;
   border: 1px solid #ccc;
   box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
   transition: transform 0.3s ease;
   overflow: hidden;
   display: none;
}
.chat-window.show {
   display: block;
}
.chat-header {
   background-color: #46a3ff;
   color: #fff;
   padding: 10px;
   border-radius: 5px 0 0 0;
   display: flex;
   align-items: center;
   justify-content: space-between;
}
.close-button {
   background-color: transparent;
   color: #fff;
   border: none;
   font-size: 20px;
   cursor: pointer;
}
.chat-content {
   height: calc(100% - 50px);
   overflow-y: auto;
   padding: 10px;
}
.chat-input {
   position: absolute;
   bottom: 0;
   width: 100%;
   padding: 10px;
}
</style>
