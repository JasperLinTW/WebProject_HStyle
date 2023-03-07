<template>
  <div class="modal fade" id="ProductCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true">
    <div class="modal-dialog  modal-lg modal-dialog-centered" role="document">
      <div class="modal-content px-5">
        <div class="modal-header">
          <h5 class="modal-title mt-1" id="myModalLabel">商品評論</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
          </button>
        </div>
        <form>
          <div class="modal-body text-start">
            <div class="form-group">
              <label for="productName" class="mb-2">商品名稱: <div></div></label>
            </div>
            <div class="form-group">
              <div class="star-rating">
                <label for="productRating" class="mb-2 me-3">商品評分: </label>
                <i v-for="(star, index) in 5" :key="index" :class="starClass(index)" @click="selectRating(index)"></i>
              </div>
            </div>
            <div class="form-group">
              <label for="productSize">尺寸: </label>
            </div>
            <div class="form-group form-floating my-3">
              <textarea class="form-control h200px" id="productComment"></textarea>
              <label for="productComment">商品評論</label>
            </div>
            <div class="form-group mb-2">
              <label for="productImage" class="mb-2">上傳照片</label>
              <input type="file" class="form-control" accept=".png, .jpg" id="productImage">
            </div>
          </div>
          <div class="modal-footer mt-0 border-0">
            <button type="button" class="btn savebtn">送出</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import Back2Top from "./Back2Top.vue"
import axios from 'axios';


export default {
  props: {
    maxRating: {
      default: 5
    },
    initialRating: {
      default: 0
    }
  },
  setup(props) {
    const selectedRating = ref(props.initialRating);
    const stars = ref(Array(props.maxRating).fill(false));

    const selectRating = (index) => {
      selectedRating.value = index + 1;
    }

    const starClass = (index) => {
      if (index < selectedRating.value) {
        return 'fa-solid fa-star';
      } else {
        return 'fa-regular fa-star';
      }
    }

    onMounted(() => {
      stars.value.splice(props.initialRating, props.maxRating - props.initialRating, true);
    });

    return {
      selectedRating,
      stars,
      selectRating,
      starClass
    }
  }
}

</script>

<style scoped>
.h200px {
  height: 200px;
}

.savebtn:not(.nav-btns button) {
  background-color: #fff;
  color: rgb(12, 13, 12);
  padding: 10px 28px;
  border-radius: 25px;
  border: 1px solid rgb(12, 13, 12);
  transition: all 0.3s ease;
}

.savebtn:not(.nav-btns button):hover {
  background-color: #000000;
  color: #fff;
  ;
  border-color: #000000;
}

.star-rating i {
  cursor: pointer;
  font-size: 15pt;
  color: rgb(255, 208, 0);
}
</style>