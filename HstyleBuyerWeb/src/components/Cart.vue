<template>
    <div class="modal come-from-modal right fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content h-100">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">我的購物車</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        商品資料
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">結帳</button>
      </div>
    </div>
  </div>
</div>
</template>

<script>

</script>
<style scoped>
.modal-dialog {
    position: fixed;
    margin: auto;
    width: 420px;
    height: 100%;
    -webkit-transform: translate3d(0%, 0, 0);
    -ms-transform: translate3d(0%, 0, 0);
    -o-transform: translate3d(0%, 0, 0);
    transform: translate3d(0%, 0, 0);
}

.modal-content {
    height: 100%;
    overflow-y: auto;
    border-radius: 0px;
}

.modal-body {
    padding: 15px 15px 80px;
}


.modal-dialog {
    right: 0;
}


</style>