<template>
   <table class="table">
      <thead>
         <tr>
            <th scope="col">編號</th>
            <th scope="col">問題</th>
            <th scope="col">問題描述</th>
            <th scope="col">詢問時間</th>
            <th scope="col"></th>
         </tr>
      </thead>
      <tbody>
         <tr v-for="question in memberQ" :key="question.customerQuestionId">
            <th scope="row">
               <div v-if="question.solutionDescription == null"><i class="fa-regular fa-circle"></i></div>
               <div v-else><i class="fa-solid fa-check"></i></div>
            </th>
            <td>{{ question.title }}</td>
            <td>{{ question.problemDescription }}</td>
            <td>{{ question.askTime }}</td>
            <td>{{ question.solutionDescription }}</td>
         </tr>
      </tbody>
   </table>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const memberQ = ref({});
const isSolve = ref(false);
const getMemberQInfo = async () => {
   await axios
      .get(`https://localhost:7243/MemberQResponse`, { withCredentials: true })
      .then((response) => {
         memberQ.value = response.data;
         console.log(memberQ.value);
      })
      .catch((error) => {
         console.error(error);
      });
};

onMounted(() => {
   getMemberQInfo();
});
</script>

<style scoped></style>
