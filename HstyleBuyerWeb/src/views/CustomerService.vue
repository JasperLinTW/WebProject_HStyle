<template>
 <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#CustomerQModal">
  顧客提問
</button>
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#MemberQModal">
  會員提問
</button>

<CustmorQForm/>
<MemberQForm/>
</template>

<script setup>
import CustmorQForm from "../components/CustomerQForm.vue";
import MemberQForm from "../components/MemberQForm.vue";
</script>

<style scoped>
</style>