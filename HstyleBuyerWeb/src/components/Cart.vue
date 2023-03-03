<template>
    <div class="modal come-from-modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content h-100">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">我的購物車</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div v-for="item in products.cartItems" class="row g-2 align-items-center border-bottom pb-2 mb-2">
                        <div class="col-md-4">
                            <img :src="item.image" class="img-fluid rounded" alt="Product Image" />
                        </div>
                        <div class="col-md-8">
                            <div class="d-flex justify-content-between align-items-center">
                                <h5 class="mb-0">{{ item.productName }}</h5>
                            </div>
                            <div class="d-flex justify-content-between align-items-center">
                                <p class="text-muted mb-0">{{ item.color + item.size }}</p>
                                <div class="btn-group" role="group">
                                    <button type="button" class="btn btn-outline-secondary btn-s" @click="minusItem(item.specId)">
                                        <i class="fa-solid fa-minus  fa-xs"></i>
                                    </button>
                                    <button type="button" class="btn btn-outline-secondary btn-s">
                                        {{ item.quantity }}
                                    </button>
                                    <button type="button" class="btn btn-outline-secondary btn-s" @click="addItem(item.specId)">
                                        <i class="fa-solid fa-plus  fa-xs"></i>
                                    </button>
                                </div>
                            </div>
                            <p class="mb-0">
                                <strong>{{ item.unitPrice * item.quantity }}</strong>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div>
                        <span>$NT {{ products.total }} 元</span>
                    </div>

                    <div class="">
                        <router-link to="/Checkout" class="nav-link targetAll">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                            檢視購物車及付款
                        </button>
                        </router-link>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const products = ref([]);

const getCartInfo = async ()=>{
    await axios.get("https://localhost:7243/api/Cart")
                .then(response => {products.value = response.data;})
                .catch(error => {console.log(error);});
}

const addItem = async (specId)=>{
    await axios.post(`https://localhost:7243/api/Cart/${specId}`)
                .then(response =>{
                    getCartInfo();
                })
                .catch(error => {console.log(error);});
}
const minusItem = async (specId)=>{
    await axios.delete(`https://localhost:7243/api/Cart/${specId}`)
                .then(response =>{
                    getCartInfo();
                })
                .catch(error => {console.log(error);});
}
onMounted(() => {
    getCartInfo();
});
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
    right: 0;
}

.modal-content {
    height: 100%;
    overflow-y: auto;
    border-radius: 0px;
}

.modal-body {
    padding: 15px 15px 80px;
}


</style>
