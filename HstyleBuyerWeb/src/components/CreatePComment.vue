<template>
  <div>
    <div class="modal fade" id="ProductCommentModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="myModalLabel">Add Product</h5>
            <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close">
            </button>
          </div>
          <form>
            <div class="modal-body">
              <div class="form-group">
                <label for="productName">Product Name</label>
                <input type="text" class="form-control" id="productName" placeholder="Enter product name">
              </div>
              <div class="form-group">
                <label for="productRating">Product Rating</label>
                <input type="number" class="form-control" id="productRating" placeholder="Enter product rating">
              </div>
              <div class="form-group">
                <label for="productSize">Product Size</label>
                <input type="text" class="form-control" id="productSize" placeholder="Enter product size">
              </div>
              <div class="form-group">
                <label for="productImage">Product Image</label>
                <input type="file" class="form-control-file" id="productImage">
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Save changes</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import Back2Top from "./Back2Top.vue"
import axios from 'axios';

</script>

<style></style>