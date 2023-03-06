<template>
    <div class="container my-5">
        <div class="order-header border-bottom border-dark">
            <div class="row mb-2 ps-4">
                <div class="col-2 text-center">訂單編號</div>
                <div class="col-2 text-center">金額</div>
                <div class="col-2 text-center">日期</div>
                <div class="col-2 text-center">付款方式</div>
                <div class="col-1 text-center">狀態</div>
                <div class="col-2 text-center">幫助</div>
            </div>
        </div>
        <div class="accordion" id="accordionExample"> 
       <div  v-for="(order, index) in orders" :key="order.orderId" class="accordion-item">
    <div class="accordion-header" :id="'heading' + index">
      <button class="accordion-button btn-order d-flex " type="button" data-bs-toggle="collapse" 
        :data-bs-target="'#collapse' + index" 
        :aria-expanded="index===0" 
        :aria-controls="'collapse' + index">
        <div class="col-2 text-center">{{ order.orderId }}</div>
                <div class="col-2 text-center">NT$ {{ order.total }}</div>
                <div class="col-2 text-center">{{ order.createdTime.slice(0, 10) }}</div>
                <div class="col-2 text-center">{{ order.payment }}</div>
                <div class="col-1 text-center">
                    <div v-if="order.statusId === 1">
                        <a :href="`https://www.sandbox.paypal.com/checkoutnow?token=${order.payInfo}`" class="alink">待付款</a>
                    </div>
                    <div v-else>
                        {{ order.status }}
                    </div> 
                </div>
                <div class="col-2  text-center">
                    <a>聯絡客服</a>
                </div>
      </button>
    </div>
    <div :id="'collapse' + index" class="accordion-collapse collapse" :class="{show}" :aria-labelledby="'heading' + index" data-bs-parent="#accordionExample">
      <div class="accordion-body">
       <div class="row bg-dark text-white font-weight-bold  py-2">
                    <div class="col-1"></div>
                    <div class="col-2">品名</div>
                    <div class="col-2">規格</div>
                    <div class="col-2">單價</div>
                    <div class="col-2">數量</div>
                    <div class="col-2">小計</div>
                    <div class="col-1"></div>
                </div>
                <div v-for="(product, index) in order.orderDetails" :key="index" class="row accordion-body border-start border-end py-3">
                    <div class="col-1"></div>
                    <div class="col-2">{{ product.productName }}</div>
                    <div class="col-2">{{ product.color }}</div>
                    <div class="col-2">{{ product.unitPrice }}</div>
                    <div class="col-2">{{ product.quantity }}</div>
                    <div class="col-2">{{ product.subTotal }}</div>
                    <div class="col-1">我要評論</div>
                </div>
                <div class="row order-item-footer py-1  border-start border-end border-bottom">
                    <div class="col-1"></div>
                    <div class="col-1">共 {{ order.orderDetails.length }} 件</div>
                    <div class="col-6"></div>
                    <div class="col-3">
                        <div class=" text-right">H幣折抵：{{ order.discount }}</div>
                    </div>
                </div>
      </div>
    </div>
  </div>
        </div>
</div>
</template>
  
  
<script setup>
import { onMounted, ref } from 'vue';
import axios from "axios";

const orders = ref([]);

const getOrdersInfo = async () => {
    await axios.get("https://localhost:7243/api/Order")
        .then(response => { 
            orders.value = response.data;
            console.log(orders.value)
        })
        .catch(error => { console.log(error); });
}
const selectProduct = ref("");
function showDetails(index) {
    // orders.value[index].showDetails = !orders.value[index].showDetails;
    selectProduct.value = index;
}
function hideDetails(index) {
    // orders.value[index].showDetails = !orders.value[index].showDetails;
    selectProduct.value = null;
}

function timeFormat(date) {
    const year = date.getFullYear();
    const month = date.getMonth() + 1;
    const day = date.getDate();

    return `${year}-${month}-${day}`
}

function getReviewLink(orderId) {
    return `review/${orderId}`;
}

function getContactLink(orderId) {
    return `contact/${orderId}`;
}

onMounted(() => {
    getOrdersInfo();
});

</script>

<style scoped>
.p-0 {
    padding: 0 !important;
}

.alink{
    text-decoration: none;
    color: #46a3ff;
    font-weight: bolder;
}

.alink:hover {
    text-decoration-line: underline;
}

.accordion-item {
    border-top: none;
    border-radius: none;

}

.accordion {
    background-color: transparent;
    --bs-accordion-border-radius: 0%;
}

.btn-order{
    background: none;
    color: #000;
    box-shadow:none;
}

.btn-order:focus{
    outline-color: none;
    box-shadow: none;
}
</style>
  