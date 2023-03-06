<template>
  <div class="container mt-5">
    <div class="row justify-content-center">
      <div class="col-md-6">
        <div class="card mt-6">
          <div class="card-header text-center fw-bold">付款成功</div>
          <div class="card-body text-center mb-4">
            感謝您的付款
          </div>
          <div class="text-center mt-5">
            <router-link class="returnbtn" to="/product">點此繼續購物</router-link>  
        </div>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
  
</script>

<style scoped>
.card{
  border: none;
}

.card-header{
  border-radius:0%;
  background-color: none;
  font-size: 15pt;
}

.a{
  text-decoration: none;
  color: #000000;
}

.returnbtn:not(.nav-btns button) {
    background-color: #fff;
    color: rgb(12, 13, 12);
    padding: 10px 28px;
    border-radius: 25px;
    border: 1px solid rgb(12, 13, 12);
    transition: all 0.3s ease;
    text-decoration: none;

}

.returnbtn:not(.nav-btns button):hover {
    background-color: #000000;
    color: #fff;
    ;
    border-color: #000000;
    text-decoration: none;
}



.mt-6{

  margin-top: 20%;
}

</style>